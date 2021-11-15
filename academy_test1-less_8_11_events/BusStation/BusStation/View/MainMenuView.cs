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
            Console.WriteLine("Hello brodyaga, how can I help you?");
        }
        
        //Клас 'MainMenuView' - показуэ тільки меню і його пункти, для відображення табл.маршрутів є суто-клас 'TripsView' 
        //    public void ShowTripsTable(List<TripModel> trips)
        //    {
        //        ShowTripsHeader();
        //        if(trips.Count==0)
        //        {
        //            ShowInfo("Табличка пуста");
        //        }
        //        foreach (var oneTrip in trips)
        //        {
        //            //Console.WriteLine($"{oneTrip.Id} : {oneTrip.DepartureTime.ToShortDateString()} : {oneTrip.TripFrom} .....");
        //            Console.WriteLine($"{oneTrip.Id,3} | {oneTrip.DepartureTime.ToShortDateString(),12} | {oneTrip.TripFrom,8}" +
        //$" | {oneTrip.ArrivalTime.ToShortDateString(),12} | {oneTrip.TripTo,8} | {oneTrip.Bus.Name,8} | {oneTrip.Bus.Capacity,13} | {oneTrip.TicketPrice,4}");
        //        }
        //    }

        public void ShowMenu(List<MenuChoiceModel> choices)
        {
            foreach (var choice in choices)
            {
                Console.WriteLine($"{choice.ChoiceId} - {choice.ChoiceText}");
            }

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
