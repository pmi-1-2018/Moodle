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
            return new List<StudentTest>();
        }

    }
}
