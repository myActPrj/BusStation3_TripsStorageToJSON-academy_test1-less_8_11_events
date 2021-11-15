using BusStation.Controller;
using System;

namespace BusStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var menuController = new MainMenuController();
            menuController.Run();
            menuController.Stop();
        }
    }
}
