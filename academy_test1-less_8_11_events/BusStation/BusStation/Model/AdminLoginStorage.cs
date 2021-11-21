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
        private AdminLoginStorage()
        {
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
