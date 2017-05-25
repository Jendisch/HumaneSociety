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
        string animalSearchType;
        string animalSearchGender;
        string animalSearchActivityLevel;


        public void DecideWhatToDoAsAnAdopter()
        {
            string choice = UserInterface.AskIfPotentialAdopterHasFilledOutAFormYet();
            switch (choice)
            {
                case "yes":
                    
                    break;
                case "no":
                    Adopter currentAdopter = AskAdopterFormQuestions();
                    AskIfAdopterWantsToSeeAnimals(currentAdopter);
                    break;
                case "back":
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    DecideWhatToDoAsAnAdopter();
                    break;
            }
        }

        private Adopter AskAdopterFormQuestions()
        {
            UserInterface.PrepareAdopterForQuestions();
            Adopter adopter = new Adopter();
            adopter.firstName = UserInterface.AskForAdopterFirstName();
            adopter.lastName = UserInterface.AskForAdopterLastName();
            adopter.phoneNumber = UserInterface.AskForAdopterPhoneNumber();
            adopter.email = UserInterface.AskForAdopterEmail();
            adopter.married = UserInterface.AskIfAdopterIsMarried();
            adopter.hasKids = UserInterface.AskIfAdopterHasChildren();
            db.Adopters.InsertOnSubmit(adopter);
            db.SubmitChanges();
            return adopter;
        }

        private void AskIfAdopterWantsToSeeAnimals(Adopter currentAdopter)
        {
            string choice = UserInterface.ThankAdopterForFillingOutTheForm();
            switch (choice)
            {
                case "yes":

                    break;
                case "no":
                    UserInterface.ThankPotentialAdopterForVisiting();
                    break;
                case "back":
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    AskIfAdopterWantsToSeeAnimals(currentAdopter);
                    break;
            }
        }

        public void BeginSearchingThroughTraitsOfAnimals()
        {
            UserInterface.DisplayWelcomeToTraitSearch();
            animalSearchType = UserInterface.AskAdopterWhatTypeOfAnimalTheyAreLookingFor();
            animalSearchGender = UserInterface.AskAdopterWhatAnimalGenderTheyAreLookingFor();
            animalSearchActivityLevel = UserInterface.AskAdopterWhatAnimalActivityLevelTheyAreLookingFor();
        }
        


//search for type, gender, and activity level


    }
}
