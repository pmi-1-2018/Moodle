using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Classes
{
    public class Question
    {
        public string Content { get; }

        public IEnumerable<Answer> Answers { get; }

        public double Mark { get; }

        public Question(string content, IEnumerable<Answer> answers, double mark)
        {
            this.Content = content;
            this.Answers = answers;
            this.Mark = mark;
        }
    }
}
