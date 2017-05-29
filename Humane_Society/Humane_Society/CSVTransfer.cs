using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;



namespace Humane_Society
{
    public class CSVTransfer
    {

        LINQtoSQLDataContext db = new LINQtoSQLDataContext();
        Employee employee = new Employee();
        Room roomForTransferAnimal;

        public string GetFilePathName()
        {
            Console.Clear();
            string file = UserInterface.GetTheFilePathName();
            Console.Clear();
            return file;
        }

        public static List<string[]> ReadCSV(string file)
        {
            var dataImport = File.ReadLines(file).Select(l => l.Split(',')).Select(x => x).ToList();
            return dataImport;
        }

        public void ImportCSV(string file)
        {
            LINQtoSQLDataContext db = new LINQtoSQLDataContext();
            var imported = ReadCSV(file);
            foreach (var input in imported)
            {
                Animal animal = new Animal();
                Trait traits = new Trait();
                Health health = new Health();
                animal.name = input[0];
                animal.breed = input[1];
                animal.age = int.Parse(input[2]);
                animal.price = double.Parse(input[3]);
                animal.entryDate = DateTime.Now;
                animal.adopted = false;
                animal.type = input[4];
                animal.gender = input[5];
                traits.size = input[6];
                traits.activityLevel = input[7];
                traits.color = input[8];
                health.receivedShots = true;
                health.foodConsumptionPerWeek = decimal.Parse(input[9]);
                
                db.Animals.InsertOnSubmit(animal);
                db.SubmitChanges();
                traits.animalId = animal.animalId;
                health.animalId = animal.animalId;
                db.Traits.InsertOnSubmit(traits);
                db.Healths.InsertOnSubmit(health);
                roomForTransferAnimal = employee.FindFirstRoomAvailableToAddNewAnimalTo();
                employee.AssignRoomVariables(roomForTransferAnimal, animal.animalId, traits.size);
                db.SubmitChanges();
            }
            Console.WriteLine("The file of new animals was successfully added to the database.\n\n\n");
        }


    } 
}
