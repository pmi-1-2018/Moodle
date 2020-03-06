using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Classes
{
   public class Teacher : User
    {
        public int FacultyID { get; }

        public Teacher(int id, string name, string surname, string password, string login, int facultyID) : base(id, name, surname, password, login)
        {
            FacultyID = facultyID;
        }
    }
}
