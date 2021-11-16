using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.View
{
    class TripsView
    {
        public event Action<string> ShowInfo = delegate { };
        public event Action<int> ShowTripsByInputId = delegate { };
        public event Action<string> ShowTripsByInputTripTo = delegate { };

        private readonly InputComponent _input;

        public TripsView()
        {
            _input = new InputComponent();
        }

        public void ShowHeader()
        {
            Console.WriteLine("Hello brodyaga, how can I help you?");
        }

        private void showTripsHeader()
        {
            //Console.WriteLine("N     DEPARTURE      FROM     .....");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"N",3} | {"DEPARTURE",12} | {"FROM",8} | {"ArrivalTime",12} | {"TripTo",8} | {"Bus.Name",8} | {"Bus.Capacity",13} | {"PRICE",4}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShowTripsTable(List<Model.TripModel> trips)
        {
            showTripsHeader();
            if (trips.Count == 0)
            {
                ShowInfo("Табличка пуста"); // не підписано, але якось планую, мабуть по ієрархії TripsView.cs->TripsViewController.cs->MainMenuView.cs: ShowInfo(msg) 
                Console.WriteLine("Табличка пуста");
            }
            foreach (var oneTrip in trips)
            {
                //Console.WriteLine($"{oneTrip.Id} : {oneTrip.DepartureTime.ToShortDateString()} : {oneTrip.TripFrom} .....");
                Console.WriteLine($"{oneTrip.Id,3} | {oneTrip.DepartureTime.ToShortDateString(),12} | {oneTrip.TripFrom,8}" +
    $" | {oneTrip.ArrivalTime.ToShortDateString(),12} | {oneTrip.TripTo,8} | {oneTrip.Bus.Name,8} | {oneTrip.Bus.Capacity,13} | {oneTrip.TicketPrice,4}");
            }
        }

        public void GoInputTripId()
        {
            Console.WriteLine("Please input Trip Id:");
            var _input = new InputComponent();
            int tripId = _input.GetInputInt();
            ShowTripsByInputId(tripId);
        }

        public void GoInputTripTo()
        {
            Console.WriteLine("Please input Trip To:");
            var _input = new InputComponent();
            String tripTo = _input.GetInputString();
            ShowTripsByInputTripTo(tripTo);
        }

    }
}
