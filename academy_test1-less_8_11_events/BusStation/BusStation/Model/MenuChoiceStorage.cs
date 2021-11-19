using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Model
{
    public class MenuChoiceStorage
    {
        public List<MenuChoiceModel> Choices { get; }

        private static MenuChoiceStorage _instance;

        private MenuChoiceStorage()
        {
            Choices = new List<MenuChoiceModel>
            {
                new MenuChoiceModel(1, "Show all"),
                new MenuChoiceModel(2, "Find by Id"),
                new MenuChoiceModel(3, "Find by destination"),
                new MenuChoiceModel(4, "Find by current day"),
                new MenuChoiceModel(5, "Find by next 7 day"),
                new MenuChoiceModel(6, "Find by ticket price less"),
                new MenuChoiceModel(7, "Find by bus capacity the more"),
                //new MenuChoiceModel(7, "Find by capacity free"),
                new MenuChoiceModel(8, "Login as Admin")
            };
        }

        public static MenuChoiceStorage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MenuChoiceStorage();
            }
            return _instance;
        }

    }
}
