﻿using System;


namespace BusStation.View
{
    public class InputComponent
    {
        public Action GoNextWaitKeyEscEventHandler = delegate { };     //GoNextWaitKeyDone GoNextWaitKeyEsc
        public int GetInputInt()
        {
            bool isParsed;
            int result;
            do
            {
                //Console.WriteLine("Enter integer, and press Enter");
                var userChoice = Console.ReadLine();
                isParsed = int.TryParse(userChoice, out result);
            } while (!isParsed);
            return result;
        }

        public string GetInputString()
        {
            string result = Console.ReadLine();
            return result;
        }

        public float GetInputMoney()
        {
            return GetInputInt();
        }

        public string GetInputPassword()
        {
            string result = Console.ReadLine();
            return result;
        }

        public bool GetConfirmQuestion()
        {
            do
            {
                string confirm = GetInputString().ToLower();
                if (confirm == "y")
                {
                    return true;
                }
                if (confirm == "n")
                {
                    return false;
                }
                Console.WriteLine("No correct input, plase repeeat input");

            } while (true);
        }
        //Затримка виведення наступної порції данних на екран, поки не буде натиснута будь-яка калавіша
        public void WaitKeyEsc()  // WaitKeyForReturnPrevMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Press 'Esc' Key for Main menu..");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
            GoNextWaitKeyEscEventHandler();
        }

    }
}
