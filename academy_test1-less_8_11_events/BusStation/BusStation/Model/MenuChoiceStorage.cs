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
                new MenuChoiceModel(3, "Find by destination")
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
