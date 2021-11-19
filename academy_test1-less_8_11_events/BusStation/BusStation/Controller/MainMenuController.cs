using BusStation.Model;
using BusStation.View;
using System.Collections.Generic;
namespace BusStation.Controller
{
    public class MainMenuController
    {
        private readonly MainMenuView _menuView;
        private readonly MenuChoiceStorage _choiceStorage;
        private readonly AdminController _login;

        public MainMenuController()
        {
            _menuView = new MainMenuView();
            _choiceStorage = MenuChoiceStorage.GetInstance();
            _login = new AdminController();
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
                case 5:
                    showTripsTableByNext7Days();
                    break;
                case 6:
                    showTripsTableByTicketPriceLess();
                    break;
                case 7:
                    showTripsTableByBusCapacityTheMore();
                    break;
                case 8:
                    showAdminLoginDialog();
                    break;
                default:
                    _menuView.ShowError("невідомий пункт меню");
                    break;
            }
        }

        public void Run()
        {
            _menuView.MenuSelected += MenuSelectedHandler;
            showMenu();
        }

        private void showMenu()
        {
            _menuView.ShowHeader();
            _menuView.ShowMenu(_choiceStorage.Choices);
        }

        public void Stop()
        {
            _menuView.MenuSelected -= MenuSelectedHandler;
        }

        private void showTripsTable()
        {
            var tripsShow = new TripsViewController();
            tripsShow.GoReturnMainMenu += showMenu;
            tripsShow.ShowTripsTable();
        }

        private void showTripsTableById()
        {
            var tripsShow = new TripsViewController();
            tripsShow.GoReturnMainMenu += showMenu;
            tripsShow.ShowTripsTableById();
        }

        private void ShowTripsTableByTripTo()
        {
            var tripsShow = new TripsViewController();
            tripsShow.GoReturnMainMenu += showMenu;
            tripsShow.ShowTripsTableByTripTo();
        }

        private void showTripsTableByCurrentDay()
        {
            var tripsShow = new TripsViewController();
            tripsShow.GoReturnMainMenu += showMenu;
            tripsShow.ShowTripsTableByCurrentDay();
        }

        private void showTripsTableByNext7Days()
        {
            var tripsShow = new TripsViewController();
            tripsShow.GoReturnMainMenu += showMenu;
            tripsShow.ShowTripsTableByNext7Days();
        }

        private void showTripsTableByTicketPriceLess()
        {
            var tripsShow = new TripsViewController();
            tripsShow.GoReturnMainMenu += showMenu;
            tripsShow.ShowTripsTableByTicketPriceLess();
        }

        private void showTripsTableByBusCapacityTheMore()
        {
            var tripsShow = new TripsViewController();
            tripsShow.GoReturnMainMenu += showMenu;
            tripsShow.ShowTripsTableByBusCapacityTheMore();
        }

        private void showAdminLoginDialog()
        {
            var userLevel = new AdminController();
            userLevel.ShowAdminLoginDialog();
        }
    }
}
