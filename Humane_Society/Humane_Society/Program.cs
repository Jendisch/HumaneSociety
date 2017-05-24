using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Humane_Society;

namespace HumaneSociety
{
    class Program
    {
        static void Main(string[] args)
        {

            //MainMenu menu = new MainMenu();
            //menu.InitiateMenu();
            //Console.ReadKey();

            Employee e = new Employee();
            e.CheckIfRoomsAreAvailable();
            Console.ReadKey();





            //LINQtoSQLDataContext db = new LINQtoSQLDataContext();

            //Adding New Animals 

            //Animal animal = db.Animals.FirstOrDefault(e => e.name.Equals("Michael"));
            //Animal animal = new Animal();
            //animal.type = "Cat";
            //animal.name = "John";
            //animal.breed = "Siamese";
            //animal.price = 100;
            //animal.entryDate = DateTime.Now;
            //animal.adopted = false;
            //animal.age = 3;

            //db.Animals.InsertOnSubmit(animal);


            ////Traits traits = db.Traits.FirstOrDefault(e => e.traitId.Equals());
            //Trait traits = new Trait();
            //traits.activityLevel = "Low";
            //traits.size = "Small";
            //traits.color = "White";
            //traits.animalId = 3;

            //db.Traits.InsertOnSubmit(traits);


            ////Room room = db.Room.FirstOrDefault(e => e.roomId.Equals());
            //Room room = new Room();
            //room.roomNumber = 3;
            //room.occupied = true;
            //room.size = "Small";
            //room.animalId = 3;

            //db.Rooms.InsertOnSubmit(room);


            //db.SubmitChanges();
        }
    }
}
