using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humane_Society
{
    class Adopt
    {

        LINQtoSQLDataContext db = new LINQtoSQLDataContext();
        Adopter currentAdopter;
        Animal animalToAdopt;

        string animalSearchType;
        string animalSearchGender;
        string animalSearchActivityLevel;
        List<Animal> correctTypes;
        List<Animal> correctGenders;
        List<int?> searchedTypeIds = new List<int?>();
        List<int?> searchedTypeAndGenderIds = new List<int?>();
        List<int?> searchedActivityLevelAnimalIds = new List<int?>();
        List<int?> animalListBasedOnAdopterTraits = new List<int?>();


        public void DecideWhatToDoAsAnAdopter()
        {
            string choice = UserInterface.AskIfPotentialAdopterHasFilledOutAFormYet();
            switch (choice)
            {
                case "yes":
                    currentAdopter = FindPreviousAdopterProfile();
                    AskIfAdopterWantsToSeeAnimals();
                    break;
                case "no":
                    currentAdopter = AskAdopterFormQuestions();
                    AskIfAdopterWantsToSeeAnimals();
                    break;
                case "back":
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    DecideWhatToDoAsAnAdopter();
                    break;
            }
        }

        private Adopter FindPreviousAdopterProfile()
        {
            string name = UserInterface.AskAdopterForPassword();
            var adopters = db.GetTable<Adopter>();
            var current = from a in adopters
                                 where a.password == name
                                 select a;
            currentAdopter = current.First();
            return currentAdopter;
        }

        private Adopter AskAdopterFormQuestions()
        {
            UserInterface.PrepareAdopterForQuestions();
            Adopter adopter = new Adopter();
            adopter.firstName = UserInterface.AskForAdopterFirstName();
            adopter.lastName = UserInterface.AskForAdopterLastName();
            adopter.password = UserInterface.AskForAdopterPassword();
            adopter.phoneNumber = UserInterface.AskForAdopterPhoneNumber();
            adopter.email = UserInterface.AskForAdopterEmail();
            adopter.married = UserInterface.AskIfAdopterIsMarried();
            adopter.hasKids = UserInterface.AskIfAdopterHasChildren();
            adopter.paidAdoptionFee = false;
            db.Adopters.InsertOnSubmit(adopter);
            db.SubmitChanges();
            return adopter;
        }

        private void AskIfAdopterWantsToSeeAnimals()
        {
            string choice = UserInterface.IntroduceAdoptertoFindingAnimalsBasedOnTraits();
            switch (choice)
            {
                case "yes":
                    BeginSearchingThroughTraitsOfAnimals();
                    break;
                case "no":
                    UserInterface.ThankPotentialAdopterForVisiting();
                    break;
                case "back":
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    AskIfAdopterWantsToSeeAnimals();
                    break;
            }
        }

        private void BeginSearchingThroughTraitsOfAnimals()
        {
            UserInterface.DisplayWelcomeToTraitSearch();
            animalSearchType = UserInterface.AskAdopterWhatTypeOfAnimalTheyAreLookingFor();
            animalSearchGender = UserInterface.AskAdopterWhatAnimalGenderTheyAreLookingFor();
            animalSearchActivityLevel = UserInterface.AskAdopterWhatAnimalActivityLevelTheyAreLookingFor();
            FindAnimalsBasedOnType();
            FindAnimalsBasedOnGender();
            FindCorrectActivityLevelTraits();
            FindDuplicatesInTypeGenderAndTraitLists();
            DisplayAvailableAnimalsAndPrice();
        }

        private void FindAnimalsBasedOnType()
        {
            var animals = db.GetTable<Animal>();
            var correctTypeOfAnimal = from a in animals
                                       where a.type == animalSearchType
                                       select a;
            correctTypes = correctTypeOfAnimal.ToList();
            foreach (var i in correctTypes)
            {
                searchedTypeIds.Add(i.animalId);
            }
        }

        private void FindAnimalsBasedOnGender()
        {
            var correctGenderOfAnimal = from a in correctTypes
                                        where a.gender == animalSearchGender
                                        select a;
            correctGenders = correctGenderOfAnimal.ToList();
            foreach (var id in correctGenders)
            {

                searchedTypeAndGenderIds.Add(id.animalId);
            }
        }

        private void FindCorrectActivityLevelTraits()
        {
            var traits = db.GetTable<Trait>();
            var correctActivityLevelOfAnimal = from a in traits
                                               where a.activityLevel == animalSearchActivityLevel
                                               select a;
            List<Trait> correctActivityLevel = correctActivityLevelOfAnimal.ToList();
            foreach (var id in correctActivityLevel)
            {

                searchedActivityLevelAnimalIds.Add(id.animalId);
            }
        }

        private void FindDuplicatesInTypeGenderAndTraitLists()
        {
            animalListBasedOnAdopterTraits = searchedTypeAndGenderIds.Intersect(searchedActivityLevelAnimalIds).ToList();
        }

        private void DisplayAvailableAnimalsAndPrice()
        {
            if (animalListBasedOnAdopterTraits.Count > 0)
            {
                for (int i = 0; i < animalListBasedOnAdopterTraits.Count; i++)
                {
                    var animals = db.GetTable<Animal>();
                    var results = from a in animals
                                  select a;
                    foreach (var value in results)
                    {
                        if (animalListBasedOnAdopterTraits[i] == value.animalId)
                        {
                            Console.WriteLine($"\n{value.name} the {value.breed} for {value.price} dollars >> animal ID = {value.animalId}");
                        }
                    }
                }
                ProceedWithAdoptionAfterPickingAnAnimal();
            }
            else
            {
                DecideWhatToDoIfTraitSearchDidntWork();
            }
        }

        private void DecideWhatToDoIfTraitSearchDidntWork()
        {
            string choice = UserInterface.DisplayNoAnimalsFittingCriteria();
            switch (choice)
            {
                case "list":
                    ShowAListOfAllAvailableAnimalsAndPrice();
                    UserInterface.PressAnyKeyToContinue();
                    BeginSearchingThroughTraitsOfAnimals();
                    break;
                case "redo":
                    BeginSearchingThroughTraitsOfAnimals();
                    break;
                case "exit":
                    DecideWhatToDoAsAnAdopter();
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    DecideWhatToDoIfTraitSearchDidntWork();
                    break;
            }
        }

        private void ShowAListOfAllAvailableAnimalsAndPrice()
        {
            var animals = db.GetTable<Animal>();
            var available = from a in animals
                            where a.adopted == false
                            select a;
            foreach (var value in available)
            {
                Console.WriteLine($"\n{value.type}: {value.name} is a {value.breed} {value.gender} for {value.price} dollars >> The animal id is {value.animalId} for this animal");
            }
        }

        private void ProceedWithAdoptionAfterPickingAnAnimal()
        {
            string choice = UserInterface.AskAdopterIfTheyWantToAdopt();
            switch (choice)
            {
                case "yes":
                    FindAnimalToBeAdopted();
                    break;
                case "no":
                    DecideWhatToDoAsAnAdopter();
                    break;
                default:
                    Console.Clear();
                    UserInterface.DisplayNotAValidResponse();
                    ProceedWithAdoptionAfterPickingAnAnimal();
                    break;
            }
        }

        private void FindAnimalToBeAdopted()
        {
            int number = UserInterface.GetAnimalIdNumberFromAdopter();
            var animals = db.GetTable<Animal>();
            var adopt = from a in animals
                                where a.animalId == number
                                select a;
            animalToAdopt = adopt.First();
            Console.Clear();
            foreach (var value in adopt)
            {
                Console.WriteLine($"\nLooks like you want to adopt {value.name} the {value.breed}!");
                ConfirmAdoption();
            }
        }

        private void ConfirmAdoption()
        {
            string choice = UserInterface.ConfirmAdoptionForAnimal(animalToAdopt.price);
            switch (choice)
            {
                case "adopt":
                    UpdateAnimalAndAdopterInformation();
                    CollectPayementFromAdopter();
                    TakeAdoptedAnimalOutOfItsRoom();
                    PrintOutReceiptAndTransferInformationToDatabase();
                    UserInterface.CongratulateAdopter();
                    break;
                case "cancel":
                    DecideWhatToDoAsAnAdopter();
                    break;
                default:
                    Console.Clear();
                    UserInterface.DisplayNotAValidResponse();
                    ProceedWithAdoptionAfterPickingAnAnimal();
                    break;
            }
        }

        private void UpdateAnimalAndAdopterInformation()
        {
            animalToAdopt.adopted = true;
            animalToAdopt.adoptiveParentId = currentAdopter.adopterId;
            animalToAdopt.adoptedDate = DateTime.Now;
            currentAdopter.adoptedAnimalId = animalToAdopt.animalId;
            currentAdopter.adoptionDate = DateTime.Now;
        }

        private void CollectPayementFromAdopter()
        {
            currentAdopter.paidAdoptionFee = true;
            var results = db.GetTable<Register>();
            var result = from r in results
                         where r.registerId == 1
                         select r;
            Register register = result.First();
            register.moneyInRegister += animalToAdopt.price;
        }

        private void TakeAdoptedAnimalOutOfItsRoom()
        {
            var rooms = db.GetTable<Room>();
            var room = from r in rooms
                       where r.animalId == animalToAdopt.animalId
                       select r;
            Room animalRoom = room.First();
            animalRoom.occupied = false;
        }

        private void PrintOutReceiptAndTransferInformationToDatabase()
        {
            Receipt receipt = new Receipt();
            receipt.adopterId = currentAdopter.adopterId;
            receipt.animalId = animalToAdopt.animalId;
            receipt.firstName = currentAdopter.firstName;
            receipt.lastName = currentAdopter.lastName;
            receipt.moneyPaid = animalToAdopt.price;
            db.Receipts.InsertOnSubmit(receipt);
            db.SubmitChanges();
        }




    }
}
