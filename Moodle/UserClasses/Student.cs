using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Classes
{
    public class Student : User
    {
        public string Group { get; }

        public Student(int id, string name, string surname, string password, string login, string group, int facultyID) : base (id, name, surname, password, login, facultyID)
        {
            Group = group;
        }
    }
}
