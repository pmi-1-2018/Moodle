using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Classes
{
    public class Answer
    {
        public string Content { get; set; }

        public bool IsRight { get; set; }

        public Answer(string content, bool isRight)
        {
            this.Content = content;
            this.IsRight = isRight;
        }
        public Answer()
        {
            this.Content = "Unknown";
            this.IsRight = false;
        }
    }
}
