using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Moodle
{
    class MainMenu
    {
        public bool DisplayStartMenu()
        {
        //    Console.Clear();
            Console.WriteLine("Welcome to the Moodle!");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Log in ");
            Console.WriteLine("2) Sign up");
            Console.WriteLine("3) Quit");
            Console.Write("\r\nSelect an option: ");

            User user = new User();

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    user.LogIntoMoodle();
                    return true;
                case "2":
                    Console.Clear();
                    user.SignUp();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
    }
}
