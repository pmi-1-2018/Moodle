using Moodle.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Services.Interfaces
{
    public interface IStudentTestDataProvider
    {
        IEnumerable<StudentTest> GetTests();
    }
}
