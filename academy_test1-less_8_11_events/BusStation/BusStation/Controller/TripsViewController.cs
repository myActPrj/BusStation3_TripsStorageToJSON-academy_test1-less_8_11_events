using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusStation.Model;

namespace BusStation.Controller
{
    class TripsViewController
    {
        private readonly View.TripsView _tripsView;
        private readonly Model.TripsStorage _tripsStorage;
        public Action ShowMenuInMainMainMenuController;
        public TripsViewController(Action ShowMenuFuncEventHandler)
        {
            _tripsStorage = TripsStorage.GetInstance();
            _tripsView = new View.TripsView();
            _tripsView.GoReturnToMainMenu += GoReturnMainMenu;
            ShowMenuInMainMainMenuController += ShowMenuFuncEventHandler;
            SubScribeAllEvents();
        }
        ~TripsViewController()
        {
            UnSubScribeAllEvents();
            _tripsView.GoReturnToMainMenu -= GoReturnMainMenu;
        }
        private void SubScribeAllEvents()
        {
            _tripsView.ShowTripsByInputId += ShowTripsTableByInputId;
            _tripsView.ShowTripsByInputTripTo += showTripsByInputTripTo;
            _tripsView.ShowTripsByTnputTripToTickedPriceLess += ShowTripsTableByTicketInputPriceLess;
            _tripsView.ShowTripsByInputBusCapacityTheMore += ShowTripsTableByInputBusCapacityTheMore;
            _tripsView.DeleteTripsByInputId += DeleteTripsByInputId;
        }
        private void UnSubScribeAllEvents()
        {
            _tripsView.ShowTripsByInputId -= ShowTripsTableByInputId;
            _tripsView.ShowTripsByInputTripTo -= showTripsByInputTripTo;
            _tripsView.ShowTripsByTnputTripToTickedPriceLess -= ShowTripsTableByTicketInputPriceLess;
            _tripsView.ShowTripsByInputBusCapacityTheMore -= ShowTripsTableByInputBusCapacityTheMore;
            _tripsView.DeleteTripsByInputId -= DeleteTripsByInputId;
        }
        private void GoReturnMainMenu()
        {
            //_tripsView.GoReturnToMainMenu -= GoReturnMainMenu;
            Console.WriteLine("Go Main menu");
            ShowMenuInMainMainMenuController();
        }

        public void ShowTripsTable()
        {
            _tripsView.ShowTripsTable(_tripsStorage.Trips);
        }

        public void ShowTripsTableById()
        {
            //_tripsView.ShowTripsByInputId += showTripsTableByInputId;
            _tripsView.GoInputTripId();
        }
        private void ShowTripsTableByInputId(int id)
        {
            var trips = Model.TripsFilter.GetTripsById(_tripsStorage.Trips, id);
            _tripsView.ShowTripsTable(trips);
            //_tripsView.ShowTripsByInputId -= showTripsTableByInputId;
        }

        public void ShowTripsTableByTripTo()
        {
            //_tripsView.ShowTripsByInputTripTo += showTripsByInputTripTo;
            _tripsView.GoInputTripTo();
        }
        private void showTripsByInputTripTo(string tripTo)
        {
            var trips = Model.TripsFilter.GetTripsByTripTo(_tripsStorage.Trips, tripTo);
            _tripsView.ShowTripsTable(trips);
            //_tripsView.ShowTripsByInputTripTo -= showTripsByInputTripTo;
        }

        public void ShowTripsTableByCurrentDay()
        {
            DateTime dateBegin = DateTime.Now;
            dateBegin = new DateTime(2022, 1, 1);   // для працездатності прикладу підставляємо "сьогоднішню дату" як 01.01.2022
            DateTime dateEnd = dateBegin.Date.AddDays(1);

            var trips = Model.TripsFilter.GetTripsByDepartureTime(_tripsStorage.Trips, dateBegin, dateEnd);
            _tripsView.ShowTripsTable(trips);
        }

        public void ShowTripsTableByNext7Days()
        {
            DateTime dateBegin = DateTime.Now;
            dateBegin = new DateTime(2022, 1, 1);   // для працездатності прикладу підставляємо "сьогоднішню дату" як 01.01.2022
            DateTime dateEnd = dateBegin.Date.AddDays(7);

            var trips = Model.TripsFilter.GetTripsByDepartureTime(_tripsStorage.Trips, dateBegin, dateEnd);
            _tripsView.ShowTripsTable(trips);
        }

        public void ShowTripsTableByTicketPriceLess()
        {
            //_tripsView.ShowTripsByTnputTripToTickedPriceLess += showTripsTableByTicketInputPriceLess;
            _tripsView.GoInputTickerPririceLess();
        }
        private void ShowTripsTableByTicketInputPriceLess(float TicketPrice)
        {
            var trips = Model.TripsFilter.GetTripByTicketPriceLess(_tripsStorage.Trips, TicketPrice);
            _tripsView.ShowTripsTable(trips);
            //_tripsView.ShowTripsByTnputTripToTickedPriceLess -= showTripsTableByTicketInputPriceLess;
        }

        public void ShowTripsTableByBusCapacityTheMore()
        {
            //_tripsView.ShowTripsByInputBusCapacityTheMore += showTripsTableByInputBusCapacityTheMore;
            _tripsView.GoInputBusCapacityIsMore();
        }
        private void ShowTripsTableByInputBusCapacityTheMore(int busCapacityTheMore)
        {
            var trips = Model.TripsFilter.GetTripByBusCapacityTheMore(_tripsStorage.Trips, busCapacityTheMore);
            _tripsView.ShowTripsTable(trips);
            //_tripsView.ShowTripsByInputBusCapacityTheMore -= showTripsTableByInputBusCapacityTheMore;
        }

        public void DeleteTripsById()
        {
            _tripsView.GoInputDeleteTripId();
        }
        private void DeleteTripsByInputId(int id)
        {
            //var trips = Model.TripsFilter.GetTripsById(_tripsStorage.Trips, id);
            //_tripsView.ShowTripsTable(trips);

            var tripStorage = TripsStorage.GetInstance();
            tripStorage.DeleteTripById(id);
            GoReturnMainMenu();
        }

    }
}
