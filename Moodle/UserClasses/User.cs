using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Moodle.Classes
{
    public abstract class User
    {
        public string Name { get;}

        public string Surname { get;}

        public int ID { get;}

        public string Email { get; }

        public string Password { get;}

        public string Login { get; }

        public int FacultyID { get; }
        public User(int id, string name, string surname, string password, string login, int facultyId)
        {
            Name = name;
            ID = id;
            Surname = surname;
            Password = password;
            Login = login;
            FacultyID = facultyId;
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
    }
}
