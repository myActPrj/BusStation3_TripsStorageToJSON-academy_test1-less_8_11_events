using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusStation.View;
using BusStation.Model;


namespace BusStation.Controller
{
    class AdminMenuController
    {
        //public bool IsAdminLogin;
        private readonly AdminMenuView _adminMenuView;
        private readonly AdminMenuChoiceStorage _adminMenuChoice;
        private readonly AdminLoginStorage _adminLoginStorage;
        private readonly MainMenuView _menuView; //_mainMenuView
        public AdminMenuController(MainMenuView mainMenuView)
        {
            _adminMenuView = new AdminMenuView();
            _adminMenuView.GoLoginByInputPasswordEvent += GoAdminLogin;
            _adminMenuChoice = AdminMenuChoiceStorage.GetInstance();
            _adminLoginStorage = AdminLoginStorage.GetInstance();

            //_mainMenuView = new MainMenuView();
            _menuView = mainMenuView;
        }
        ~AdminMenuController()
        {
            _adminMenuView.GoLoginByInputPasswordEvent -= GoAdminLogin;
        }
        public void ShowAdminLoginDialog()
        {
            _adminMenuView.ShowAdminLoginDialog(_adminLoginStorage);
        }
        public void GoAdminLogin(string inputPassword)
        {
            ShwowAdminMenu();
        }


        private void ShwowAdminMenu()
        {
            _menuView.ShowHeader(_adminMenuChoice.MenuName);
            _menuView.ShowMenu(_adminMenuChoice.Choices, MenuSelectedEvent);
        }

        private void MenuSelectedEvent(int menu)
        {
            switch (menu)
            {
                case 1:
                    ShowTripsTable();
                    break;
                //case 2:
                //    AddNewTrip();
                    //break;
                case 3:
                    //EditTripById();
                    break;
                case 4:
                    DeleteTripById();
                    break;
                case 5:
                    break;
            }
        }

        private void ShowTripsTable()
        {
            var tripsShow = new TripsViewController(ShwowAdminMenu);
            tripsShow.ShowTripsTable();
        }

        //private void AddNewTrip()
        //{
        //    var tripsShow = new TripsViewController(ShwowAdminMenu);
        //    tripsShow.AddNewTrip();
        //}

        //private void EditTripById();
        private void DeleteTripById()
        {
            var tripsShow = new TripsViewController(ShwowAdminMenu);
            tripsShow.DeleteTripsById();
        }

    }
}
