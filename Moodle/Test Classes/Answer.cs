using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Classes
{
    public class Answer
    {
        public string Content { get; }

        public bool IsRight { get; }

        public Answer(string content, bool isRight)
        {
            this.Content = content;
            this.IsRight = isRight;
        }
    }
}
