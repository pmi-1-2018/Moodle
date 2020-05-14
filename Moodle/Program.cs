using System;
using System.Data.SQLite;
using System.IO;


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

        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            string path = Path.Combine(Environment.CurrentDirectory, @"../../../", "moodleDb.db");
            string connetionString = "Data Source=" + path + ";";
            sqlite_conn = new SQLiteConnection(connetionString);
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                
            }
            return sqlite_conn;
            
        }

    }
}
