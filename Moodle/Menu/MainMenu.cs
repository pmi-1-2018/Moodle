using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Moodle
{
    class MainMenu
    {
        public bool DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Moodle!");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Log in ");
            Console.WriteLine("2) Sign un");
            Console.WriteLine("3) Test");
            Console.WriteLine("3) Download test");
            Console.WriteLine("5) Exit");
            Console.Write("\r\nSelect an option: ");

            User user = new User();

            switch (Console.ReadLine())
            {
                case "1":
                    user.LogIntoMoodle();
                    return true;
                case "2":
                    // Sign up function
                    return true;
                case "3":
                    //Test function
                    return true;
                case "4":
                    //Download test function
                    return true;
                case "5":
                    return false;
                default:
                    return true;
            }
        }
    }
}
