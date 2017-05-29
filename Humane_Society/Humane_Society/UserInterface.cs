using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humane_Society
{
    static class UserInterface
    {

        //General

        public static void DisplayNotAValidResponse()
        {
            Console.WriteLine("Not a valid response. Please enter a new response.");
        }

        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public static void DisplayWrongKeyTyped()
        {
            Console.WriteLine("You have typed an invalid key. Please begin again.");
        }


        //MainMenu

        public static void WelcomeGreetingToMenu()
        {
            Console.WriteLine("Welcome to Animal Mills R' Us!");
            Console.WriteLine("Where you can find the animal of your dreams.");
        }

        public static string AskIfEmployeeOrPotentialAdopter()
        {
            Console.WriteLine("Are you an 'employee' of Animal Mills R' Us or a potential 'adopter'? \nPlease input one of the two choices or type 'exit' to leave the humane society.");
            string choice = Console.ReadLine();
            return choice;
        }

        public static string TypeEmployeePassword()
        {
            Console.Clear();
            Console.WriteLine("Please enter the employee password and press any key to continue. Enter 'back' to return to a previous menu.");
            string choice = Console.ReadLine();
            return choice;
        }


        //Employee

        public static int DisplayOptionsForEmployeeToAccomplish()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("What would you like to accomplish today?");
                Console.WriteLine("Enter a number: \n(1) Import transfer files from another humane society \n(2) Add a new animal to the database \n(3) Display list of occupied rooms \n(4) Remove an animal from database(Animal died) \n(5) Display count of animals based on their type \n(6) Display animals and their food consumption per week in cups \n(7) to exit");
                string choice = Console.ReadLine();
                int number = int.Parse(choice);
                return number;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return DisplayOptionsForEmployeeToAccomplish();
            }
        }

        public static void ExplainFoodConsumptionList()
        {
            Console.WriteLine("Every type of animal is fed Fromm brand food. Listed below is the amount of cups per week every animal should be eating.");
        }

        public static void ExplainRoomLimit(int currentAnimals)
        {
            Console.WriteLine("There is a room limit here at Animal Mills R' Us. We have the space to offer a home to 100 animals.");
            Console.WriteLine($"Currently there are {currentAnimals} animals that have a home here.");
        }

        public static void ShowThatThereIsEnoughRoomForANewAnimal()
        {
            Console.WriteLine("It looks like there's enough room!");
        }

        public static void ShowThatThereIsNotEnoughRoomForANewAnimal()
        {
            Console.WriteLine("It looks like we're all full here unfortunately.");
        }

        public static string InformEmployeeOfSeverityOfDeletingARecord()
        {
            try
            {
                Console.WriteLine("Deleting an animal from the database is something that is only done when an animal has passed away during its stay.");
                Console.WriteLine("Has the animal passed away? Please respond with yes or no.");
                string choice = Console.ReadLine().ToLower();
                return choice;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return InformEmployeeOfSeverityOfDeletingARecord();
            }
        }

        public static string AskIfTheEmployeeKnowsTheAnimalIdOfTheAnimalToDelete()
        {
            try
            {
                Console.WriteLine("Do you know the animal Id of the animal? Please respond with yes or no.");
                string choice = Console.ReadLine().ToLower();
                return choice;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskIfTheEmployeeKnowsTheAnimalIdOfTheAnimalToDelete();
            }
        }

        public static void ShowAnimalAndAnimalIdIntro()
        {
            Console.WriteLine("Here is a list of all unadopted animals, their breed, and their animal Id number.");
        }

        public static int AskForAnimalIdOfAnimalToDelete()
        {
            try
            {
                Console.WriteLine("Please enter the animal Id of the animal you wish to delete from the database.");
                string choice = Console.ReadLine();
                int number = int.Parse(choice);
                return number;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskForAnimalIdOfAnimalToDelete();
            }
        }

        public static void ShowSuccessfulAnimalDeletion()
        {
            Console.WriteLine("The animal has been deleted from the database.");
        }



        //Employee - Adding in animal responses



        public static void DisplayIntroToAddingAnAnimal()
        {
            Console.WriteLine("Please have all information on the animal available to you before continuing.");
        }

        public static string AskTypeOfAnimal()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the type of new animal (Dog, Cat, Rabbit, etc.).");
                string choice = Console.ReadLine().ToLower();
                return choice;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskTypeOfAnimal();
            }
        }

        public static string AskGenderOfAnimal()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the gender of new animal. 'Male' or 'Female'?");
                string choice = Console.ReadLine().ToLower();
                if (choice == "male")
                {
                    return choice;
                }
                else if (choice == "female")
                {
                    return choice;
                }
                else
                {
                    DisplayWrongKeyTyped();
                    PressAnyKeyToContinue();
                    return AskGenderOfAnimal();
                }
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskGenderOfAnimal();
            }
        }

        public static string AskNameOfAnimal()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the name of the new animal.");
                string choice = Console.ReadLine();
                return choice;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskNameOfAnimal();
            }
        }

        public static string AskBreedOfAnimal()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the breed of the new animal. If the breed is not known for sure, type your best guess.");
                string choice = Console.ReadLine();
                return choice;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskBreedOfAnimal();
            }
        }

        public static double AskPriceOfAnimal()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the selling price of the new animal.");
                string choice = Console.ReadLine();
                double number = double.Parse(choice);
                return number;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskPriceOfAnimal();
            }
        }

        public static decimal AskAgeOfAnimal()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the age of the new animal. If the age is not known for sure, type your best guess.");
                string choice = Console.ReadLine();
                decimal number = decimal.Parse(choice);
                return number;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskAgeOfAnimal();
            }
        }

        public static string AskSizeOfAnimal()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the size of the new animal. Use 'large', 'medium', or 'small'. Only Dogs should use the categoies of Large or Medium.");
                string choice = Console.ReadLine().ToLower();
                if (choice == "large")
                {
                    return choice;
                }
                else if (choice == "medium")
                {
                    return choice;
                }
                else if(choice == "small")
                {
                    return choice;
                }
                else
                {
                    DisplayWrongKeyTyped();
                    PressAnyKeyToContinue();
                    return AskSizeOfAnimal();
                }
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskSizeOfAnimal();
            }
        }

        public static string AskColorOfAnimal()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the color of the new animal.");
                string choice = Console.ReadLine().ToLower();
                return choice;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskColorOfAnimal();
            }
        }

        public static string AskActivityLevelOfAnimal()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the activity level of the new animal. Please use 'high', 'medium', or 'low'.");
                string choice = Console.ReadLine().ToLower();
                if (choice == "high")
                {
                    return choice;
                }
                else if (choice == "medium")
                {
                    return choice;
                }
                else if (choice == "low")
                {
                    return choice;
                }
                else
                {
                    DisplayWrongKeyTyped();
                    PressAnyKeyToContinue();
                    return AskActivityLevelOfAnimal();
                }
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskActivityLevelOfAnimal();
            }
        }

        public static decimal AskAboutFoodConsumptionOfAnimal()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the approximate food consumption in cups per week of the new animal.");
                Console.WriteLine("For example - The average large dog eats about 28 cups per week and the average cat eats about 11.");
                string choice = Console.ReadLine();
                decimal number = decimal.Parse(choice);
                return number;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskAboutFoodConsumptionOfAnimal();
            }
        }

        public static void AskIfShotsAreUpToDateOnAnimal()
        {
            Console.Clear();
            Console.WriteLine("Are all of the shots up to date? If you are unsure please give them the necessary shots for their age before they are brought into the facility.");
        }

        public static string ConfirmTheAdditionOfTheAnimal()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Are you sure you want to add this animal to the database? Please type 'yes or 'no'.");
                string choice = Console.ReadLine().ToLower();
                return choice;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return ConfirmTheAdditionOfTheAnimal();
            }
        }


        //Adopt


        public static string AskIfPotentialAdopterHasFilledOutAFormYet()
        {
            Console.Clear();
            Console.WriteLine("Have you filled out an adoption form yet? Please type 'yes' or 'no'. If you'd like to return to the precious menu type 'back'.");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }

        public static void PrepareAdopterForQuestions()
        {
            Console.WriteLine("There's a series of questions we'd like to ask you to make sure that you're a good candidate for one of our animals!");
            PressAnyKeyToContinue();
        }

        public static string AskForAdopterFirstName()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Please enter your first name.");
                string choice = Console.ReadLine();
                return choice;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskForAdopterFirstName();
            }
        }

        public static string AskForAdopterLastName()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Please enter your last name.");
                string choice = Console.ReadLine();
                return choice;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskForAdopterLastName();
            }
        }

        public static string AskForAdopterPassword()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Please enter a password for your profile.");
                string choice = Console.ReadLine();
                return choice;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskForAdopterPassword();
            }
        }

        public static double AskForAdopterPhoneNumber()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Please enter a phone number that's best to reach you at. Please enter your number including the area code but excluding the dashes (ex. 2625551234).");
                string choice = Console.ReadLine();
                double number = double.Parse(choice);
                return number;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskForAdopterPhoneNumber();
            }
        }

        public static string AskForAdopterEmail()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Please enter the email that's best to reach you at.");
                string choice = Console.ReadLine();
                return choice;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskForAdopterEmail();
            }
        }


        public static bool AskIfAdopterIsMarried()
        {
            try
            {
                Console.Clear();
                bool yesOrNo;
                Console.WriteLine("Are you married? Please enter 'yes' or 'no'.?");
                string choice = Console.ReadLine().ToLower();
                if (choice == "yes")
                {
                    yesOrNo = true;
                    return yesOrNo;
                }
                else if (choice == "no")
                {
                    yesOrNo = false;
                    return yesOrNo;
                }
                else
                {
                    DisplayWrongKeyTyped();
                    PressAnyKeyToContinue();
                    return AskIfAdopterIsMarried();
                }
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskIfAdopterIsMarried();
            }
        }

        public static bool AskIfAdopterHasChildren()
        {
            try
            {
                Console.Clear();
                bool yesOrNo;
                Console.WriteLine("Do you have any children? Please enter 'yes' or 'no'.?");
                string choice = Console.ReadLine().ToLower();
                if (choice == "yes")
                {
                    yesOrNo = true;
                    return yesOrNo;
                }
                else if (choice == "no")
                {
                    yesOrNo = false;
                    return yesOrNo;
                }
                else
                {
                    DisplayWrongKeyTyped();
                    PressAnyKeyToContinue();
                    return AskIfAdopterHasChildren();
                }
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskIfAdopterHasChildren();
            }
        }

        public static string IntroduceAdoptertoFindingAnimalsBasedOnTraits()
        {
            try
            {
                Console.WriteLine("Would you like to begin your traits search through our animals that are available for adoption? Please enter 'yes' or 'no'.");
                string choice = Console.ReadLine().ToLower();
                return choice;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return IntroduceAdoptertoFindingAnimalsBasedOnTraits();
            }
        }

        public static void ThankPotentialAdopterForVisiting()
        {
            Console.WriteLine("Come back anytime! Continue your application by entering your last name when you return.");
            PressAnyKeyToContinue();
        }

        public static void DisplayWelcomeToTraitSearch()
        {
            Console.WriteLine("We like to sort animals based on three major traits. Type of animal, gender of animal, and activity level of animal.");
        }

        public static string AskAdopterWhatTypeOfAnimalTheyAreLookingFor()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("What type of animal are you looking for? (Dog, Cat, Rabbit, etc.).");
                string choice = Console.ReadLine().ToLower();
                return choice;
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskAdopterWhatTypeOfAnimalTheyAreLookingFor();
            }
        }

        public static string AskAdopterWhatAnimalGenderTheyAreLookingFor()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("What gender of animal are you looking for? Please enter 'male' or 'female'.");
                string choice = Console.ReadLine().ToLower();
                if (choice == "male")
                {
                    return choice;
                }
                else if (choice == "female")
                {
                    return choice;
                }
                else
                {
                    DisplayWrongKeyTyped();
                    PressAnyKeyToContinue();
                    return AskGenderOfAnimal();
                }
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskAdopterWhatAnimalGenderTheyAreLookingFor();
            }
        }

        public static string AskAdopterWhatAnimalActivityLevelTheyAreLookingFor()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("What animal activity level are you searching for? Please use 'high', 'medium', or 'low'.");
                string choice = Console.ReadLine().ToLower();
                if (choice == "high")
                {
                    return choice;
                }
                else if (choice == "medium")
                {
                    return choice;
                }
                else if (choice == "low")
                {
                    return choice;
                }
                else
                {
                    DisplayWrongKeyTyped();
                    PressAnyKeyToContinue();
                    return AskAdopterWhatAnimalActivityLevelTheyAreLookingFor();
                }
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return AskAdopterWhatAnimalActivityLevelTheyAreLookingFor();
            }
        }

        public static string DisplayNoAnimalsFittingCriteria()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Sorry we couldn't find any animals matching all of your search criteria.");
                Console.WriteLine("Would you like to see a 'list' of all of our animals, 'redo' your trait search, or 'exit' the current menu and go back to the main adopter menu.?");
                Console.WriteLine("Please enter 'list', 'redo', or 'exit'.");
                string choice = Console.ReadLine().ToLower();
                if (choice == "list")
                {
                    return choice;
                }
                else if (choice == "redo")
                {
                    return choice;
                }
                else if (choice == "exit")
                {
                    return choice;
                }
                else
                {
                    DisplayWrongKeyTyped();
                    PressAnyKeyToContinue();
                    return DisplayNoAnimalsFittingCriteria();
                }
            }
            catch
            {
                DisplayWrongKeyTyped();
                PressAnyKeyToContinue();
                return DisplayNoAnimalsFittingCriteria();
            }
        }

        public static string AskAdopterIfTheyWantToAdopt()
        {
            Console.WriteLine("\nDo you want to adopt an animal above? Please answer 'yes' or 'no'.");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }

        public static int GetAnimalIdNumberFromAdopter()
        {
            Console.WriteLine("Please enter the animal id number of the animal you'd like to adopt!");
            string choice = Console.ReadLine();
            int number = int.Parse(choice);
            return number;
        }

        public static string ConfirmAdoptionForAnimal(double? animalPrice)
        {
            Console.WriteLine($"Please type 'adopt' to move forward with the adoption and process your payment of ${animalPrice}.00. Type 'cancel' to cancel the adoption and return to the menu.");
            string choice = Console.ReadLine().ToLower();
            return choice;
        }

        public static string AskAdopterForPassword()
        {
            Console.WriteLine("Please enter your profile password so we can find your previous application.");
            string choice = Console.ReadLine();
            return choice;
        }

        public static void CongratulateAdopter()
        {
            Console.WriteLine("Congratulations on your new addition to your family! Please come again if you'd like to adopt another animal.");
            PressAnyKeyToContinue();
        }



        //CSVTransfer




        public static string GetTheFilePathName()
        {
            Console.WriteLine("Enter the path to the CSV file and press any key to continue: ");
            string choice = Console.ReadLine();
            return choice;
        }




    }
}

