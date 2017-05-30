using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.IEnumerable;

namespace Humane_Society
{
    class Employee
    {

        LINQtoSQLDataContext db = new LINQtoSQLDataContext();
        CSVTransfer newCSV;


        public void DecideWhatToDoAsAnEmployee()
        {
            int choice = UserInterface.DisplayOptionsForEmployeeToAccomplish();
            switch (choice)
            {
                case 1:
                    InputCSVDataIntoDatabase();
                    break;
                case 2:
                    CheckIfRoomsAreAvailable();
                    break;
                case 3:
                    DisplayAllAnimalsAndRoomNumbers();
                    break;
                case 4:
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

        private void InputCSVDataIntoDatabase()
        {
            newCSV = new CSVTransfer();
            string file = newCSV.GetFilePathName();
            newCSV.ImportCSV(file);
            UserInterface.PressAnyKeyToContinue();
            DecideWhatToDoAsAnEmployee();
        }

        private void CheckIfRoomsAreAvailable()
        {
            var animals = db.GetTable<Animal>();
            var currentAnimals = from a in animals
                                 where a.adopted == false
                                 select a;
            int animalCount = currentAnimals.Count();
            UserInterface.ExplainRoomLimit(animalCount);
            if (animalCount < 100)
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
            try
            {
                Animal animal = new Animal();
                Trait traits = new Trait();
                Health health = new Health();
                UserInterface.DisplayIntroToAddingAnAnimal();
                UserInterface.PressAnyKeyToContinue();
                animal.type = UserInterface.AskTypeOfAnimal();
                animal.gender = UserInterface.AskGenderOfAnimal();
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
                UserInterface.AskIfShotsAreUpToDateOnAnimal();
                string choice = UserInterface.ConfirmTheAdditionOfTheAnimal();
                if (choice == "yes")
                {
                    db.Animals.InsertOnSubmit(animal);
                    db.SubmitChanges();
                    Room firstRoom = FindFirstRoomAvailableToAddNewAnimalTo();
                    AssignRoomVariables(firstRoom, animal.animalId, traits.size);
                    traits.animalId = animal.animalId;
                    health.animalId = animal.animalId;
                    db.Traits.InsertOnSubmit(traits);
                    db.Healths.InsertOnSubmit(health);
                    db.SubmitChanges();
                    UserInterface.PressAnyKeyToContinue();
                    DecideWhatToDoAsAnEmployee();
                }
                else if (choice == "no")
                {
                    DecideWhatToDoAsAnEmployee();
                }
                else
                {
                    UserInterface.DisplayWrongKeyTyped();
                    AddNewAnimalToDatabase();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                UserInterface.DisplayWrongKeyTyped();
                AddNewAnimalToDatabase();
            }
        }
        


        public Room FindFirstRoomAvailableToAddNewAnimalTo()
        {
            var rooms = db.GetTable<Room>();
            var first = from r in rooms
                        where r.occupied == false
                        select r;
            var firstRoom = first.First(f => f.occupied == false);
            return firstRoom;
        }

        public void AssignRoomVariables(Room firstRoom, int animalId, string traitsSize)
        {
            firstRoom.size = traitsSize;
            firstRoom.occupied = true;
            firstRoom.animalId = animalId;
        }

        private void DisplayAllAnimalsAndRoomNumbers()
        {
            Console.Clear();
            var animals = db.GetTable<Animal>();
            var currentAnimals = animals.Where(a => a.adopted == false);
            var rooms = db.GetTable<Room>();

            var query = rooms.Join<Room, Animal, int?, dynamic>(currentAnimals,
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
            string choice = UserInterface.InformEmployeeOfSeverityOfDeletingARecord();
            switch (choice)
            {
                case "yes":
                    string response = UserInterface.AskIfTheEmployeeKnowsTheAnimalIdOfTheAnimalToDelete();
                    if(response == "yes")
                    {
                        SearchForAnimalToDelete();
                        UserInterface.ShowSuccessfulAnimalDeletion();
                        UserInterface.PressAnyKeyToContinue();
                        DecideWhatToDoAsAnEmployee();
                    }
                    else
                    {
                        DisplayAllActiveAnimalsBreedAndTheirAnimalId();
                        RemoveAnimalFromDatabase();
                    }
                    break;
                case "no":
                    DecideWhatToDoAsAnEmployee();
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    RemoveAnimalFromDatabase();
                    break;
            }
        }

        private void SearchForAnimalToDelete()
        {
            int number = UserInterface.AskForAnimalIdOfAnimalToDelete();
            Animal animalToDelete = db.Animals.First(n => n.animalId.Equals(number));
            Trait traitToDelete = db.Traits.First(t => t.animalId.Equals(number));
            Health healthToDelete = db.Healths.First(h => h.animalId.Equals(number));
            Room roomToDelete = FindRoomToEmpyt(number);
            roomToDelete.size = null;
            roomToDelete.occupied = false;
            roomToDelete.animalId = null;
            db.Animals.DeleteOnSubmit(animalToDelete);
            db.Traits.DeleteOnSubmit(traitToDelete);
            db.Healths.DeleteOnSubmit(healthToDelete);
            db.SubmitChanges();
        }

        private Room FindRoomToEmpyt(int number)
        {
            var rooms = db.GetTable<Room>();
            var first = from r in rooms
                        where r.animalId == number
                        select r;
            var firstRoom = first.First(f => f.animalId == number);
            return firstRoom;
        }

        private void DisplayAllActiveAnimalsBreedAndTheirAnimalId()
        {
            Console.Clear();
            UserInterface.ShowAnimalAndAnimalIdIntro();
            var animals = db.GetTable<Animal>();
            var currentAnimals = animals.Where(a => a.adopted == false);
            foreach (var animal in currentAnimals.ToList())
            {
                Console.WriteLine($"\n>>{animal.name}: {animal.breed} -----> Id = {animal.animalId}");
            }
        }

        private void DisplayAnimalsInGroupsByType()
        {
            Console.Clear();
            var animals = db.GetTable<Animal>();
            var currentAnimals = animals.Where(a => a.adopted == false);
            var animalGroups = currentAnimals.Select(i => i.type).Distinct().Count();
            var group = from a in currentAnimals
                        group a by a.type
                        into b
                        select new
                      {
                          animalGroup = b.Key,
                          count = b.Select(x => x.animalId).Distinct().Count()
                      };
            foreach (var row in group.OrderBy(x => x.animalGroup))
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
