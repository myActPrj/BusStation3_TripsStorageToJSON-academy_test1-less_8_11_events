using BusStation.Model;
using BusStation.View;
using System.Collections.Generic;
namespace BusStation.Controller
{
    public class ShowTripsTableByCurrentDay
    {
        private readonly MainMenuView _menuView;
        private readonly MenuChoiceStorage _choiceStorage;

        public ShowTripsTableByCurrentDay()
        {
            _menuView = new MainMenuView();
            _choiceStorage = MenuChoiceStorage.GetInstance();
        }

        private void MenuSelectedHandler(int menu)
        {
            switch (menu)
            {
                case 1:
                    showTripsTable();
                    break;
                case 2:
                    showTripsTableById();
                    break;
                case 3:
                    ShowTripsTableByTripTo();
                    break;
                case 4:
                    showTripsTableByCurrentDay();
                    break;
                //case 5:
                //    ShowTripsTableByNext7Days();
                //    break;
                //case 6:
                //    ShowTripsTableByTicketPriceLess();
                //    break;
                //case 7:
                //    ShowTripsTableByCapacity(); //CapacityFree
                //    break;
                //case 8:
                //    LoginAsAdmin();
                //    break;
                default:
                    _menuView.ShowError("невідомий пункт меню");
                    break;
            }
        }

        public void Run()
        {
            _menuView.MenuSelected += MenuSelectedHandler;

            _menuView.ShowHeader();
            _menuView.ShowMenu(_choiceStorage.Choices);
        }

        public void Stop()
        {
            _menuView.MenuSelected -= MenuSelectedHandler;
        }

        private void showTripsTable()
        {
            //if (TripsStorage.LoadTrips()) // не виріши як краще, чи перевіряти на корректність данних (якщо TripsStorage.Trips буде сам оновлюватися кожен раз з файла)
            //_menuView.ShowTripsTable(TripsStorage.Trips);
            var tripsShow = new TripsViewController();
            tripsShow.ShowTripsTable();
        }

        private void showTripsTableById()
        {
            var tripsShow = new TripsViewController();
            tripsShow.ShowTripsTableById();
        }

        private void ShowTripsTableByTripTo()
        {
            var tripsShow = new TripsViewController();
            tripsShow.ShowTripsTableByTripTo();
        }

        private void showTripsTableByCurrentDay()
        {
            var tripsShow = new TripsViewController();
            tripsShow.ShowTripsTableByCurrentDay();
        }

    }
}
