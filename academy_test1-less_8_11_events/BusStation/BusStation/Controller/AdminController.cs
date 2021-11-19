using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Controller
{
    class AdminController
    {

        //public bool IsAdminLogin;
       
        private readonly AdminView _adminView;
        private readonly AdminLoginStorage _adminStorage;

        public AdminController()
        {
            _adminView = new AdminView();
            _adminStorage = AdminLoginStorage.GetInstance();

        }

        public void ShowAdminLoginDialog()
        {
            _adminView.GoLoginByInputPassword += GoAdminLogin;
            _adminView.ShowAdminLoginDialog(_adminStorage);
        }
        public void GoAdminLogin(string inputPassword)
        {
            Console.WriteLine("користувач авторизувався...");
            _adminView.GoLoginByInputPassword -= GoAdminLogin;
        }

    }
}
