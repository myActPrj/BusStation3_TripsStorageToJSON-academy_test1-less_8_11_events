using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Controller
{
    class AdminMenuView
    {
        public event Action<string> GoLoginByInputPasswordEvent = delegate { };

        private View.InputComponent _input;

        public AdminMenuView()
        {
            _input = new View.InputComponent();
        }
        //public void ShowHeader()
        //{
        //    //Console.Clear();
        //    Console.WriteLine("---------------------------------");
        //    Console.WriteLine("ADMIN MENU:");
        //}
        public void ShowAdminLoginDialog(AdminLoginStorage adminStorage)
        {
            bool isIputedPassword = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Autoriration");
                Console.WriteLine($"Login: {adminStorage.LoginName} (pass: '1')");
                Console.Write("Password: ");

                string inputPassword = _input.GetInputPassword();

                if (adminStorage.LoginPassword == inputPassword)
                {
                    isIputedPassword = true;
                    GoLoginByInputPasswordEvent(inputPassword);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Inputed password is no Correct");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("for try again press any key, for cancell press Esc");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        isIputedPassword = true;
                    }
                }

            } while (!isIputedPassword);

        }
    }
}
