using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.IEnumerable;

namespace Humane_Society
{
    class Employee
    {

        LINQtoSQLDataContext db = new LINQtoSQLDataContext();


        public void DecideWhatToDoAsAnEmployee()
        {
            int choice = UserInterface.DisplayOptionsForEmployeeToAccomplish();
            switch (choice)
            {
                case 1:
                    //Import transfer files from another humane society
                    ImputTransferHumaneSocietyDataIntoDatabase();
                    break;
                case 2:
                    CheckIfRoomsAreAvailable();
                    break;
                case 3:
                    DisplayAllAnimalsAndRoomNumbers();
                    break;
                case 4:
                    //Remove an animal from database
                    RemoveAnimalFromDatabase();
                    break;
                case 5:
                    DisplayAnimalsInGroupsByType();
                    break;
                case 6:
                    DisplayAnimalsAndTheirFoodConsumptionPerWeek();
                    break;
                case 7:
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    DecideWhatToDoAsAnEmployee();
                    break;
            }
        }

        private void ImputTransferHumaneSocietyDataIntoDatabase()
        {

        }


        public void CheckIfRoomsAreAvailable()
        {
            var animals = db.GetTable<Animal>();
            int currentAnimals = animals.Count();
            UserInterface.ExplainRoomLimit(currentAnimals);
            if (currentAnimals < 100)
            {
                UserInterface.ShowThatThereIsEnoughRoomForANewAnimal();
                AddNewAnimalToDatabase();
            }
            else
            {
                UserInterface.ShowThatThereIsNotEnoughRoomForANewAnimal();
                UserInterface.PressAnyKeyToContinue();
                DecideWhatToDoAsAnEmployee();
            }
        }

        private void AddNewAnimalToDatabase()
        {
            Animal animal = new Animal();
            Trait traits = new Trait();
            Health health = new Health();
            UserInterface.DisplayIntroToAddingAnAnimal();
            UserInterface.PressAnyKeyToContinue();
            animal.type = UserInterface.AskTypeOfAnimal();
            animal.name = UserInterface.AskNameOfAnimal();
            animal.breed = UserInterface.AskBreedOfAnimal();
            animal.price = UserInterface.AskPriceOfAnimal();
            animal.entryDate = DateTime.Now;
            animal.adopted = false;
            animal.age = UserInterface.AskAgeOfAnimal();
            traits.size = UserInterface.AskSizeOfAnimal();
            traits.color = UserInterface.AskColorOfAnimal();
            traits.activityLevel = UserInterface.AskActivityLevelOfAnimal();
            health.foodConsumptionPerWeek = UserInterface.AskAboutFoodConsumptionOfAnimal();
            health.receivedShots = true;
            room.occupied = true;
            room.size = traits.size;
            UserInterface.AskIfShotsAreUpToDateOnAnimal();

            
                                                    //Looking to try to insert new animals into the first open room!
            db.Animals.InsertOnSubmit(animal);
            db.Traits.InsertOnSubmit(traits);
            db.Rooms.InsertOnSubmit(room);
            db.Healths.InsertOnSubmit(health);


            traits.animalId = animal.animalId;
            room.animalId = animal.animalId;
            health.animalId = animal.animalId;



            db.SubmitChanges();
        }


        
        //room.roomNumber = 3;

        //db.SubmitChanges();


        



        private void DisplayAllAnimalsAndRoomNumbers()
        {
            Console.Clear();
            var animals = db.GetTable<Animal>();
            var rooms = db.GetTable<Room>();

            var query = rooms.Join<Room, Animal, int?, dynamic>(animals,
                r => r.animalId,
                a => a.animalId,
                (r, a) => new { r.roomNumber, a.name });
            foreach (var group in query.ToList())
            {
                Console.WriteLine($"Room {group.roomNumber}: {group.name}");
            }
            UserInterface.PressAnyKeyToContinue();
            DecideWhatToDoAsAnEmployee();
        }




        private void RemoveAnimalFromDatabase()
        {

        }

        public void DisplayAnimalsInGroupsByType()
        {
            Console.Clear();
            var animals = db.GetTable<Animal>();
            var animalGroups = animals.Select(i => i.type).Distinct().Count();
            var qry = from a in db.Animals
                      group a by a.type
                      into b
                      select new
                      {
                          animalGroup = b.Key,
                          count = b.Select(x => x.animalId).Distinct().Count()
                      };
            foreach (var row in qry.OrderBy(x => x.animalGroup))
            {
                Console.WriteLine($"{row.animalGroup}: { row.count}");
            }
            UserInterface.PressAnyKeyToContinue();
            DecideWhatToDoAsAnEmployee();
        }

        private void DisplayAnimalsAndTheirFoodConsumptionPerWeek()
        {
            Console.Clear();
            UserInterface.ExplainFoodConsumptionList();
            var animals = db.GetTable<Animal>();
            var health = db.GetTable<Health>();

            var query = animals.Join<Animal, Health, int?, dynamic>(health,
                a => a.animalId,
                h => h.animalId,
                (a, h) => new { a.name, h.foodConsumptionPerWeek });
            foreach (var group in query.ToList())
            {
                Console.WriteLine($">>{group.name}: consumes about {group.foodConsumptionPerWeek} cups of food a week");
            }
            UserInterface.PressAnyKeyToContinue();
            DecideWhatToDoAsAnEmployee();
        }



    }
}
