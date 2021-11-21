using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Model
{
    public class AdminMenuChoiceStorage
    {
        public List<MenuChoiceModel> Choices { get; }

        private static AdminMenuChoiceStorage _instance;

        private AdminMenuChoiceStorage()
        {
            Choices = new List<MenuChoiceModel>
            {
                new MenuChoiceModel(1, "Show all"),
                //new MenuChoiceModel(2, "Add new trip"),
                //new MenuChoiceModel(3, "Edit trip by Id"),
                new MenuChoiceModel(4, "Delete trip by Id"),
                new MenuChoiceModel(5, "Return main menu")
            };
        }

        public static AdminMenuChoiceStorage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AdminMenuChoiceStorage();
            }
            return _instance;
        }

        public string MenuName = "MAIN MENU -> ADMIN MENU:";

    }
}
