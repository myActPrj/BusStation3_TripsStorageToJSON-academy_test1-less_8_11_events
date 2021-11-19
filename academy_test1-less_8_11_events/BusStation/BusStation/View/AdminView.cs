using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Controller
{
    class AdminView
    {
        public event Action<string> GoLoginByInputPassword = delegate { };

        private View.InputComponent _input;


        public AdminView()
        {
            _input = new View.InputComponent();
        }

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

                if (adminStorage.IsPasswordCorrect(inputPassword))
                {
                    isIputedPassword = true;
                    GoLoginByInputPassword(inputPassword);
                }
                else
                {
                    Console.WriteLine("Inputed password is no Correct");
                    Console.WriteLine("for try again press any key, for cancell press Esc");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        isIputedPassword = true;
                    }
                }

            } while (!isIputedPassword);

        }
    }
}
