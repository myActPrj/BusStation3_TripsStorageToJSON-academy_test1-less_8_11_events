using BusStation.Model;
using BusStation.View;
namespace BusStation.Controller
{
    public class MainMenuController
    {
        private readonly MainMenuView _menuView;
        private readonly MenuChoiceStorage _choiceStorage;
        private readonly AdminMenuController _login;

        public MainMenuController()
        {
            _menuView = new MainMenuView();
            _choiceStorage = MenuChoiceStorage.GetInstance();
            //_login = new AdminMenuController();
        }

        private void MenuSelectedEvent(int menu)
        {
            switch (menu)
            {
                case 1:
                    ShowTripsTable();
                    break;
                case 2:
                    ShowTripsTableById();
                    break;
                case 3:
                    ShowTripsTableByTripTo();
                    break;
                case 4:
                    ShowTripsTableByCurrentDay();
                    break;
                case 5:
                    ShowTripsTableByNext7Days();
                    break;
                case 6:
                    ShowTripsTableByTicketPriceLess();
                    break;
                case 7:
                    ShowTripsTableByBusCapacityTheMore();
                    break;
                case 8:
                    ShowAdminLoginDialog();
                    break;
                default:
                    _menuView.ShowError("невідомий пункт меню");
                    break;
            }
        }

        public void Run()
        {
            //_menuView.MenuSelectedEvent += MenuSelectedEvent;
            ShowMenu();
        }

        private void ShowMenu()
        {
            _menuView.ShowHeader(_choiceStorage.MenuName);
            _menuView.ShowMenu(_choiceStorage.Choices, MenuSelectedEvent);

            //tripsShow.ShowMenuInMainMainMenuController -= showMenu;
        }
        //private void ShowAdminMenu()
        //{
        //    _menuView.ShowHeader(_choiceStorage.MenuName);
        //    _menuView.ShowMenu(_choiceStorage.Choices);
        //}

        public void Stop()
        {
            //_menuView.MenuSelectedEvent -= MenuSelectedEvent;
            //_tripsShow.ShowMenuInMainMainMenuController -= showMenu;
            //_tripsShow = null;
        }

        private void ShowTripsTable()
        {
            var tripsShow = new TripsViewController(ShowMenu);
            tripsShow.ShowTripsTable();
        }

        private void ShowTripsTableById()
        {
            var tripsShow = new TripsViewController(ShowMenu);
            tripsShow.ShowTripsTableById();
        }

        private void ShowTripsTableByTripTo()
        {
            var tripsShow = new TripsViewController(ShowMenu);
            tripsShow.ShowTripsTableByTripTo();
        }

        private void ShowTripsTableByCurrentDay()
        {
            var tripsShow = new TripsViewController(ShowMenu);
            tripsShow.ShowTripsTableByCurrentDay();
        }

        private void ShowTripsTableByNext7Days()
        {
            var tripsShow = new TripsViewController(ShowMenu);
            tripsShow.ShowTripsTableByNext7Days();
        }

        private void ShowTripsTableByTicketPriceLess()
        {
            var tripsShow = new TripsViewController(ShowMenu);
            tripsShow.ShowTripsTableByTicketPriceLess();
        }

        private void ShowTripsTableByBusCapacityTheMore()
        {
            var tripsShow = new TripsViewController(ShowMenu);
            tripsShow.ShowTripsTableByBusCapacityTheMore();
        }

        private void ShowAdminLoginDialog()
        {
            var userLevel = new AdminMenuController(_menuView);
            userLevel.ShowAdminLoginDialog();
        }
    }
}
