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
            Console.WriteLine("Not a valid response. Please type one of the options below.");
        }

        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }


        //MainMenu

        public static void WelcomeGreetingToMenu()
        {
            Console.WriteLine("Welcome to Animal Mills R' Us!");
            Console.WriteLine("Where you can find the animal of your dreams.");
        }

        public static string AskIfEmployeeOrPotentialAdopter()
        {
            Console.WriteLine("Are you an 'employee' of Animal Mills R' Us or a potential 'adopter'? Please input one of the two choices and press any key to continue.");
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
            Console.Clear();
            Console.WriteLine("What would you like to accomplish today?");
            Console.WriteLine("Enter a number: \n(1) Import transfer files from another humane society \n(2) Add a new animal to the database \n(3) Display list of occupied rooms \n(4) Remove an animal from database \n(5) Display count of animals based on their type \n(6) Display animals and their food consumption per week in cups \n(7) to exit");
            string choice = Console.ReadLine();
            int number = int.Parse(choice);
            return number;
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


        //Employee - Adding an animal responses

        public static void DisplayIntroToAddingAnAnimal()
        {
            Console.WriteLine("So excited to be getting a new humane society addition!");
            Console.WriteLine("Please have all information on the animal available to you before continuing.");
        }

        public static string AskTypeOfAnimal()
        {
            Console.Clear();
            Console.WriteLine("Enter the type of new animal (Dog, Cat, Rabbit, etc.). Please capitalize first letter.");
            string choice = Console.ReadLine();
            return choice;
        }

        public static string AskNameOfAnimal()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the new animal.");
            string choice = Console.ReadLine();
            return choice;
        }

        public static string AskBreedOfAnimal()
        {
            Console.Clear();
            Console.WriteLine("Enter the breed of the new animal. If the breed is not known for sure, type your best guess.");
            string choice = Console.ReadLine();
            return choice;
        }

        public static double AskPriceOfAnimal()
        {
            Console.Clear();
            Console.WriteLine("Enter the selling price of the new animal.");
            string choice = Console.ReadLine();
            double number = double.Parse(choice);
            return number;
        }

        public static decimal AskAgeOfAnimal()
        {
            Console.Clear();
            Console.WriteLine("Enter the age of the new animal. If the age is not known for sure, type your best guess.");
            string choice = Console.ReadLine();
            decimal number = decimal.Parse(choice);
            return number;
        }

        public static string AskSizeOfAnimal()
        {
            Console.Clear();
            Console.WriteLine("Enter the size of the new animal. Use 'Large', 'Medium', or 'Small'. Only Dogs should use the categoies of Large or Medium.");
            string choice = Console.ReadLine();
            return choice;
        }

        public static string AskColorOfAnimal()
        {
            Console.Clear();
            Console.WriteLine("Enter the color of the new animal.");
            string choice = Console.ReadLine();
            return choice;
        }

        public static string AskActivityLevelOfAnimal()
        {
            Console.Clear();
            Console.WriteLine("Enter the activity level of the new animal. Please use 'High', 'Medium', or 'Low'.");
            string choice = Console.ReadLine();
            return choice;
        }

        public static decimal AskAboutFoodConsumptionOfAnimal()
        {
            Console.Clear();
            Console.WriteLine("Enter the approximate food consumption in cups per week of the new animal.");
            Console.WriteLine("For example - The average large dog eats about 28 cups per week and the average cat eats about 11.");
            string choice = Console.ReadLine();
            decimal number = decimal.Parse(choice);
            return number;
        }

        public static void AskIfShotsAreUpToDateOnAnimal()
        {
            Console.Clear();
            Console.WriteLine("Are all of the shots up to date? If you are unsure please give them the necessary shots for their age before they are brought into the facility.");
        }

















    }
}
