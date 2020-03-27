using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.TestClasses
{
    public class StudentTestInfo
    {
        public int Mark { get; }
        public string TestName { get; }
        public int StudentID { get; }
        public StudentTestInfo(int studentId, string testName, int mark)
        {
            StudentID = studentId;
            TestName = testName;
            Mark = mark;
        }
    }
}
