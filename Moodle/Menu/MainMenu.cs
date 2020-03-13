using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Menu
{
    class MainMenu
    {
        public static bool DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Moodle!");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Log in ");
            Console.WriteLine("2) Option 2");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    // Log in function here
                    return true;
                case "2":
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
    }
}
