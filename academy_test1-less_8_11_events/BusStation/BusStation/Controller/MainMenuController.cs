using BusStation.Model;
using BusStation.View;
using System.Collections.Generic;
namespace BusStation.Controller
{
    public class MainMenuController
    {
        private readonly MainMenuView _menuView;
        private readonly MenuChoiceStorage _choiceStorage;

        public MainMenuController()
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
                //case 4:
                //    ShowTripsTableByCurrentDay();
                //    break;
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
            
            //int id = 1;

            //List<TripModel> trips = TripsFilterStorage.GetTripsById(TripsStorage.Trips, id);
            //// _menuView.ShowTripsTable(trips);
            var tripsShow = new TripsViewController();
            tripsShow.ShowTripsTableById();
        }

        private void ShowTripsTableByTripTo()
        {
            System.Console.WriteLine("І ще не реалізовано.... Soryy");
        }

    }
}
