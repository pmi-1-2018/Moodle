using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Classes
{
    public class StudentTest
    {
        public IList<Question> ListOfQuestions { get; }
        public string Author { get; }
        public int ID { get; private set; }
        public string Name { get; }
        public DateTime Date { get; }
        public double MinResult { get; }
        public bool CanRetake { get; }
        public void SetID(int id)
        {
            ID = id;
        }
        public StudentTest(int id, string name, string author, DateTime dateTime, IList<Question> listOfQuestions, double minResult, bool canRetake)
        {
            ID = id;
            this.Name = name;
            this.Author = author;
            this.Date = dateTime;
            this.ListOfQuestions = listOfQuestions;
            this.CanRetake = canRetake;
            this.MinResult = minResult;
        }

    }
}
