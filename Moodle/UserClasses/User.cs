using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.SQLite;
using Moodle.Classes;
using System.Linq;

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
                        RunTest();
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

        private Test GetTestFromDB()
        {
            Console.WriteLine("\n\n\nAvailable tests : ");
            SQLiteConnection sqlite_conn;
            SQLiteDataReader sqlite_reader;
            SQLiteCommand sqlite_cmd;
            sqlite_conn = Program.CreateConnection();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM tests";
            sqlite_reader = sqlite_cmd.ExecuteReader();

            List<Test> availableTests = new List<Test>();
            if (sqlite_reader.HasRows)
            {
                int i = 0;
                while (sqlite_reader.Read())
                {
                    i++;
                    Test test = new Test();
                    test.Id = sqlite_reader.GetInt32(0);
                    test.Name = sqlite_reader.GetString(1);
                    availableTests.Add(test);
                    Console.WriteLine("{0}. {1}", i, test.Name);
                }
                sqlite_reader.Close();
            }
            else
            {
                Console.WriteLine("Tests not found.\n");
                sqlite_reader.Close();
            }

            Console.Write("\nPlease input test number : ");
            int testNumberToRun = Convert.ToInt32(Console.ReadLine());
            testNumberToRun--;
            Test result = availableTests[testNumberToRun];
            sqlite_conn = Program.CreateConnection();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM questions WHERE test_id = " + result.Id + ";"; 
            sqlite_reader = sqlite_cmd.ExecuteReader();

            if (sqlite_reader.HasRows)
            {
                while (sqlite_reader.Read())
                {
                    Question question = new Question();
                    question.Id = sqlite_reader.GetInt32(0);
                    question.Content = sqlite_reader.GetString(1);
                    question.Mark = sqlite_reader.GetDouble(2);
                    question.TestId = sqlite_reader.GetInt32(3);
                    result.Questions.Add(question);
                }
                sqlite_reader.Close();
            }
            else
            {
                Console.WriteLine("Questions not found.\n");
                sqlite_reader.Close();
            }

            for(int i = 0; i < result.Questions.Count; i++)
            {
                sqlite_conn = Program.CreateConnection();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM answers WHERE question_id = " + result.Questions[i].Id + ";";
                sqlite_reader = sqlite_cmd.ExecuteReader();

                if (sqlite_reader.HasRows)
                {
                    while (sqlite_reader.Read())
                    {
                        Answer answer = new Answer();
                        answer.Id = sqlite_reader.GetInt32(0);
                        answer.Content = sqlite_reader.GetString(1);
                        answer.IsRight = sqlite_reader.GetBoolean(2);
                        answer.Number = sqlite_reader.GetInt32(3);
                        answer.QuestionId = sqlite_reader.GetInt32(4);
                        result.Questions[i].Answers.Add(answer);
                    }
                    sqlite_reader.Close();
                }
                else
                {
                    Console.WriteLine("Answers not found.\n");
                    sqlite_reader.Close();
                }
            }
            return result;
        }

        private void RunTest()
        {
            Test test = GetTestFromDB();
            Console.WriteLine("\n\n\nTest name : {0}\n\n", test.Name);
            double mark = 0.0;
            string studentAnswer = "";
            for (int i = 0; i < test.Questions.Count; i++)
            {
                Console.WriteLine("{0}. {1}", (i+1), test.Questions[i].Content);
                Console.WriteLine();
                for (int j = 0; j < test.Questions[i].Answers.Count; j++)
                {
                    Console.WriteLine("{0}. {1}", test.Questions[i].Answers[j].Number, test.Questions[i].Answers[j].Content);
                }
                Console.Write("\nPlease input your answers (separated by comma) : ");
                studentAnswer = Console.ReadLine();
                Console.WriteLine();
                int[] answers = studentAnswer.Split(',').Select(str => int.Parse(str)).ToArray();
                mark += test.Questions[i].CheckAnswer(new HashSet<int>(answers));
            }
            Console.WriteLine("\nResult : {0}", mark);
        }
    }
}
