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
        public event Action<int> MenuSelected = delegate { };

        private readonly InputComponent _input;

        public MainMenuView()
        {
            _input = new InputComponent();
        }
        
        public void ShowHeader()
        {
            //Console.Clear();
            Console.WriteLine("MAIN MENU:");
        }
        
        public void ShowMenu(List<MenuChoiceModel> choices)
        {
            foreach (var choice in choices)
            {
                Console.WriteLine($"{choice.ChoiceId} - {choice.ChoiceText}");
            }
            Console.WriteLine("-----------");
            var isCorrect = false;
            do
            {
                var userChoice = _input.GetInputInt();
                if (choices.Any(ch => ch.ChoiceId == userChoice))
                {
                    isCorrect = true;
                    MenuSelected(userChoice);
                }
            } while (!isCorrect);
        }

        public void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR!!: "+ message);
            Console.ResetColor();
        }
        //private void ShowTripsHeader()
        //{
        //    //Console.WriteLine("N     DEPARTURE      FROM     .....");
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine($"{"N",3} | {"DEPARTURE",12} | {"FROM",8} | {"ArrivalTime",12} | {"TripTo",8} | {"Bus.Name",8} | {"Bus.Capacity",13} | {"PRICE",4}");
        //    Console.ForegroundColor = ConsoleColor.White;
        //}
        public void ShowInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("INFO!!: " + message);
            Console.ResetColor();
        }
        public void ShowWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("WARNING!!: " + message);
            Console.ResetColor();
        }

    }
}
