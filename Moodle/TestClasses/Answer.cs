using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Classes
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsRight { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int Number { get; set; }
    }
}
