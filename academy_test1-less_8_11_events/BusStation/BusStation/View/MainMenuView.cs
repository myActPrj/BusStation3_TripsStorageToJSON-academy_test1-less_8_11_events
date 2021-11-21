using BusStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.View
{
    public class MainMenuView
    {
        //public event Action<int> MenuSelectedEvent = delegate { };

        private readonly InputComponent _input;

        public MainMenuView()
        {
            _input = new InputComponent();
        }

        private void ShowBorderLine()
        {
            Console.WriteLine("---------------------------------");
        }
        public void ShowHeader(string menuName)
        {
            Console.Clear();
            ShowBorderLine();
            //Console.WriteLine("MAIN MENU:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(menuName);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShowMenu(List<MenuChoiceModel> choices, Action<int> menuSelectedEventHandler)
        {
            foreach (var choice in choices)
            {
                Console.WriteLine($"{choice.ChoiceId} - {choice.ChoiceText}");
            }
            ShowBorderLine();
            
            var isCorrect = false;
            do
            {
                var userChoice = _input.GetInputInt();
                if (choices.Any(ch => ch.ChoiceId == userChoice))
                {
                    isCorrect = true;
                    menuSelectedEventHandler(userChoice);
                }
            } while (!isCorrect);

        }

        //public void WaitSelectMenuChoice(List<MenuChoiceModel> choices)
        //{
        //    var isCorrect = false;
        //    do
        //    {
        //        var userChoice = _input.GetInputInt();
        //        if (choices.Any(ch => ch.ChoiceId == userChoice))
        //        {
        //            isCorrect = true;
        //            MenuSelectedEvent(userChoice);
        //        }
        //    } while (!isCorrect);
        //}

        public void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR!!: "+ message);
            Console.ResetColor();
        }
        //public void ShowInfo(string message)
        //{
        //    Console.ForegroundColor = ConsoleColor.Blue;
        //    Console.WriteLine("INFO!!: " + message);
        //    Console.ResetColor();
        //}
        //public void ShowWarning(string message)
        //{
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.WriteLine("WARNING!!: " + message);
        //    Console.ResetColor();
        //}

    }
}
