using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Classes
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<Answer> Answers { get; set; }
        public double Mark { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public Question()
        {
            Test = new Test();
            Answers = new List<Answer>();
        }
        public double CheckAnswer(HashSet<int> actualAnswers)
        {
            HashSet<int> rightAnswers = new HashSet<int>();
            for (int i = 0; i < this.Answers.Count; i++)
            {
                if (this.Answers[i].IsRight)
                {
                    rightAnswers.Add(this.Answers[i].Number);
                }
            }
            if (actualAnswers.SetEquals(rightAnswers))
            {
                return this.Mark;
            }
            else
            {
                return 0.0;
            }
        }
    }
}