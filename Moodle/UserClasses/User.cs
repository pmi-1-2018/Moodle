using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.SQLite;

namespace Moodle
{
    public class User
    {
        public string Name { get; }

        public string Surname { get; }

        public int ID { get; }

        public string Email { get; }

        public string Password { get; }

        public string Login { get; }

        public int FacultyID { get; }

        public User()
        {
            Name = null;
            Surname = null;
            ID = 0;
            Email = null;
            Password = null;
            Login = null;
        }
        public User(int id, string name, string surname,string email ,string password, string login)
        {
            Name = name;
            ID = id;
            Surname = surname;
            Email = email;
            Password = password;
            Login = login;
  //          FacultyID = facultyId;
        }


        public bool isEmailValid(string email)
        {
            try
            {
                var email_addres = new System.Net.Mail.MailAddress(email);
                return email_addres.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool isPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a - z])(?=.*[A - Z])(?=.*\d)(?=.*[^\da - zA - Z]).{ 8,15}$");
        }

        public User LogIntoMoodle()
        {
            User user = new User();
            Console.WriteLine("Please input your login or email\n");
            string login = Console.ReadLine();
            SQLiteConnection sqlite_conn;
            sqlite_conn = Program.CreateConnection();

            SQLiteDataReader sqlite_reader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM users" +
                " WHERE email='" + login + "' OR login='" + login + "';";

            sqlite_reader = sqlite_cmd.ExecuteReader();

            if (sqlite_reader.HasRows)
            {
                while (sqlite_reader.Read())
                {
                    int id = sqlite_reader.GetInt32(0);
                    string name = sqlite_reader.GetString(1);
                    string surname = sqlite_reader.GetString(2);
                    string email = sqlite_reader.GetString(3);
                    string password = sqlite_reader.GetString(4);
                    string log = sqlite_reader.GetString(5);
                    Console.WriteLine("Input your password:");
                    string pass = "";
                    while (true)
                    {
                        var key = System.Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        pass += key.KeyChar;
                    }
                    if ((pass == password) && (pass != null))
                    {
                        user = new User(id,name, surname, email, password,log);
                        sqlite_reader.Close();
                        Console.WriteLine($"Logged in as {log}");
                        Console.ReadKey();
                        return user;
                    }
                    else
                    {
                        Console.WriteLine("Wrong password.\n");
                        sqlite_reader.Close();
                        return user;
                    }
                }
                sqlite_reader.Close();
                return user;
            }
            else
            {
                Console.WriteLine("User not found.\n");
                sqlite_reader.Close();

                return user;
            }
        }
    }
}
