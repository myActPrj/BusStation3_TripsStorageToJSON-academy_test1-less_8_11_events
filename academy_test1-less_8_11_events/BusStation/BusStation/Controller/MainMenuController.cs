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
                    ShowTripsTable();
                    break;
                case 2:
                    ShowTripsTableById();
                    break;


                default:
                    _menuView.ShowError();
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

        private void ShowTripsTable()
        {
            //if (TripsStorage.LoadTrips()) // не виріши як краще, чи перевіряти на корректність данних (якщо TripsStorage.Trips буде сам оновлюватися кожен раз з файла)
            _menuView.ShowTripsTable(TripsStorage.Trips);
        }

        private void ShowTripsTableById()
        {
            
            int id = 1;

            List<TripModel> trips;
            trips = TripsStorage.GetById(TripsStorage.Trips, id);

            _menuView.ShowTripsTable(trips);
        }


    }
}
