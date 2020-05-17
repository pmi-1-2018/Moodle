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

        public bool SignUp()
        {
            Console.WriteLine("Create new account\n");
            Console.WriteLine("Input your email:");
            string email;
            string login;
            email = Console.ReadLine();

            while (isEmailValid(email) == false)
            {
                Console.WriteLine("Email is not valid, please try again");
                email = Console.ReadLine();
            }

            SQLiteConnection sqlite_conn;
            sqlite_conn = Program.CreateConnection();

            SQLiteDataReader sqlite_reader;
            SQLiteCommand sqlite_cmd1;
            SQLiteCommand sqlite_cmd2;
            sqlite_cmd1 = sqlite_conn.CreateCommand();
            sqlite_cmd1.CommandText = "SELECT * FROM users" +
                " WHERE email='" + email + "';";
            sqlite_reader = sqlite_cmd1.ExecuteReader();

            if (sqlite_reader.HasRows)
            {
                Console.Clear();
                Console.WriteLine("User with such email already exist");
                return false;
            }

            Console.WriteLine("Input your login:");
            login = Console.ReadLine();

            sqlite_cmd2 = sqlite_conn.CreateCommand();
            sqlite_cmd2.CommandText = "SELECT * FROM users" +
                " WHERE login='" + login + "';";
            sqlite_reader = sqlite_cmd2.ExecuteReader();
            if (sqlite_reader.HasRows)
            {
                Console.Clear();
                Console.WriteLine("User with such login already exist");
                return false;
            }

            string name;
            string surname;
            string password;
            password = "";

            Console.WriteLine("Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Surname: ");
            surname = Console.ReadLine();
            Console.WriteLine("Password: ");
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                password += key.KeyChar;
            }

            string conf_pass;
            conf_pass = "";
            Console.WriteLine("Confirm password: ");
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                conf_pass += key.KeyChar;
            }

            if(password == conf_pass)
            {
                User user = new User(0,name,surname,email,password,login);
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO users (Name, Surname, email, password, login)" +
                    " VALUES ('" + user.Name +"','" + user.Surname + "','" + user.Email + "','" + user.Password + "','" + user.Login +"')";
                sqlite_cmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("Account created");
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Passwords are not the same");
                return false;
            }
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
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        pass += key.KeyChar;
                    }
                    if ((pass == password) && (pass != null))
                    {
                        user = new User(id,name, surname, email, password,log);
                        sqlite_reader.Close();
                        Console.Clear();
                        Console.WriteLine($"Logged in as {log}");
                        MainMenu menu = new MainMenu();
                        bool displayMenu = true;
                        while (displayMenu)
                        {
                            displayMenu = menu.DisplayStartMenu();
                        }
                        Console.ReadKey();
                        return user;
                    }
                    else
                    {
                        Console.Clear();
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
                Console.Clear();
                Console.WriteLine("User not found.\n");
                sqlite_reader.Close();

                return user;
            }
        }
    }
}
