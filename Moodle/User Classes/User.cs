using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Classes
{
    public abstract class User
    {
        public string Name { get;}

        public string Surname { get;}

        public int ID { get;}

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
    }
}
