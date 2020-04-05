using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Classes
{
    public class Question
    {
        public string Content { get; set; }

        public IEnumerable<Answer> Answers { get; set; }

        public double Mark { get; set; }

        public Question(string content, IEnumerable<Answer> answers, double mark)
        {
            this.Content = content;
            this.Answers = answers;
            this.Mark = mark;
        }
        public Question()
        {
            this.Content = "Unknown";
            this.Answers = new List<Answer>();
            this.Mark = 0.0;
        }
    }
}
