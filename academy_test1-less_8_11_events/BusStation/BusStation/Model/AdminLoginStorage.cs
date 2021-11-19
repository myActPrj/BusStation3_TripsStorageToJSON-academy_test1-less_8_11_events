using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Controller
{
    class AdminLoginStorage
    {
        public string LoginName = "Admin";
        public string LoginPassword = "1";

        private static AdminLoginStorage _instance;

        public bool IsPasswordCorrect(string password)
        {
            if (password == LoginPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static AdminLoginStorage GetInstance()
        {
            if(_instance==null)
            {
                _instance = new AdminLoginStorage();
            }
            return _instance;
        }

    }
}
