using BusStation.Controller;
using System;

namespace BusStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var menuController = new ShowTripsTableByCurrentDay();
            menuController.Run();
            menuController.Stop();
        }
    }
}
