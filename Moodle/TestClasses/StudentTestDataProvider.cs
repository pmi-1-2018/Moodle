using Moodle.Classes;
using Moodle.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.TestClasses
{
    public class StudentTestDataProvider : IStudentTestDataProvider
    {
        public IEnumerable<StudentTest> GetTests()
        {
            return new List<StudentTest>() { GetTest("data.txt") };
        }
        private StudentTest GetTest(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            List<Question> questions = new List<Question>();
            StudentTest studentTest = new StudentTest();
            studentTest.Name = lines[0];
            studentTest.ID = Int32.Parse(lines[1]);
            studentTest.Author = lines[2];
            studentTest.Date = DateTime.Parse(lines[3]);
            studentTest.MaxResult = Convert.ToDouble(lines[4]);
            if(lines[5] == "yes")
            {
                studentTest.CanRetake = true;
            }
            else if(lines[5] == "no")
            {
                studentTest.CanRetake = false;
            }
            for (int i = 6; i < lines.Length; i++)
            {
                if (lines[i] == "#questionbegin")
                {
                    Question question = new Question();
                    Answer answer = new Answer();
                    question.Mark = Convert.ToDouble(lines[++i]);
                    question.Content = lines[++i];
                    List<Answer> answers = new List<Answer>();
                    while (lines[i + 1] != "#questionend")
                    {
                        i++;
                        if (lines[i][0] == 'y')
                        {
                            answer.IsRight = true;
                        }
                        else if (lines[i][0] == 'n')
                        {
                            answer.IsRight = false;
                        }
                        answer.Content = lines[i].Substring(2);
                        answers.Add(answer);
                        answer = new Answer();
                    }
                    question.Answers = answers;
                    questions.Add(question);
                }
            }
            studentTest.ListOfQuestions = questions;
            return studentTest;
        }
    }
}
