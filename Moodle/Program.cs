using System;
using static Moodle.Menu.MainMenu;

namespace Moodle
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //     Console.WriteLine("Hello World!");

        //}

        static void Main(string[] args)
        {

            //var menu = new MainMenu();
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = DisplayMenu();
            }
        }

    }
}
