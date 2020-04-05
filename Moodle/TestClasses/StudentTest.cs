using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Classes
{
    public class StudentTest
    {
        public IList<Question> ListOfQuestions { get; set; }
        public string Author { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double MaxResult { get; set; }
        public bool CanRetake { get; set; }
        public StudentTest(int id, string name, string author, DateTime dateTime, IList<Question> listOfQuestions, double maxResult, bool canRetake)
        {
            ID = id;
            this.Name = name;
            this.Author = author;
            this.Date = dateTime;
            this.ListOfQuestions = listOfQuestions;
            this.CanRetake = canRetake;
            this.MaxResult = maxResult;
        }
        public StudentTest()
        {
            ID = 0;
            this.Name = "Unknown";
            this.Author = "Unknown";
            this.Date = new DateTime();
            this.ListOfQuestions = new List<Question>();
            this.CanRetake = false;
            this.MaxResult = 0;
        }
    }
}
