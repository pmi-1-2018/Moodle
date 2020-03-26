using System;


namespace Moodle
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = menu.DisplayMenu();
            }
        }

    }
}
