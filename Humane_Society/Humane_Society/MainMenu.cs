using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humane_Society
{
    class MainMenu
    {

        Employee employee;


        public void InitiateMenu()
        {
            UserInterface.WelcomeGreetingToMenu();
            EnterEmployeeMenuOrAdopterMenu();



        }

        private void EnterEmployeeMenuOrAdopterMenu()
        {
            string choice = UserInterface.AskIfEmployeeOrPotentialAdopter().ToLower();
            switch (choice)
            {
                case "employee":
                    GoToEmployeeMenu();
                    break;
                case "adopter":
                    GoToAdopterMenu();
                    break;
                case "exit":
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    EnterEmployeeMenuOrAdopterMenu();
                    break;
            }
        }

        private void GoToEmployeeMenu()
        {
            string choice = UserInterface.TypeEmployeePassword();
            switch (choice)
            {
                case "answer":
                    employee = new Employee();
                    employee.DecideWhatToDoAsAnEmployee();
                    break;
                case "back":
                    EnterEmployeeMenuOrAdopterMenu();
                    break;
                default:
                    UserInterface.DisplayNotAValidResponse();
                    GoToEmployeeMenu();
                    break;
            }
        }

        private void GoToAdopterMenu()
        {

        }





    }
}
