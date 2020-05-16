using Moodle.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.TestClasses
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public List<UserTest> UserTests { get; set; }
        public Test()
        {
            UserTests = new List<UserTest>();
        }
    }
}
