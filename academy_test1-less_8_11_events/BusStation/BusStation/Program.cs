using BusStation.Controller;
using System;

namespace BusStation
{
    class Program
    {
        static void Main(string[] args)
        {
            var menuController = new MainMenuController();
            menuController.Run();
            menuController.Stop();
        }
    }
}
