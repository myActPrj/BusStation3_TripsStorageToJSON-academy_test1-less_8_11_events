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

        public void ShowTripsTable(List<TripModel> trips)
        {
            ShowTripsHeader();
            foreach (var oneTrip in trips)
            {
                Console.WriteLine($"{oneTrip.Id} : {oneTrip.DepartureTime.ToShortDateString()} : {oneTrip.TripFrom} .....");
            }
        }

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

        public void ShowError()
        {
            Console.WriteLine("ERROR!!");
        }

        private void ShowTripsHeader()
        {
            Console.WriteLine("N     DEPARTURE      FROM     .....");
        }
    }
}
