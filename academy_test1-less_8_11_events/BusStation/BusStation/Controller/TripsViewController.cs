using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Controller
{
    class TripsViewController
    {
        private readonly View.TripsView _tripsView;

        public TripsViewController()
        {
            _tripsView = new View.TripsView();
        }
        public void ShowTripsTable()
        {
            _tripsView.ShowTripsTable(Model.TripsStorage.Trips);
        }
        public void ShowTripsTableById()    //викликаєтся з меню
        {
            _tripsView.ShowTripsByInputId += showTripsTableByInputId;   //підписалися на подію закінчення вводу користувачем іd в модулі View
            _tripsView.GoInputTripId();                                 //запускаэмо ф-ю вводу користувачем іd потрібного маршруту в модулі View
        }
        private void showTripsTableByInputId(int id) //викликаєтся з події View  //ф-я виводе табличку маршрутів по вказаному id -як  
        {
            var trips = Model.TripsFilterStorage.GetTripsById(Model.TripsStorage.Trips, id);
            _tripsView.ShowTripsTable(trips);
            _tripsView.ShowTripsByInputId -= showTripsTableByInputId;   //відписуємося від події
        }

    }
}
