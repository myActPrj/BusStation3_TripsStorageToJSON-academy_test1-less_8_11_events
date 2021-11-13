using BusStation.Model;
using BusStation.View;

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
            _menuView.ShowTripsTable(TripsStorage.Trips);
        }
    }
}
