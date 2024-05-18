using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        //public List<string> ProgrammingLanguages { get; set; }
        public List<Techs> ProgrammingLanguages { get; set; }

    }

    class Techs
    {
        public string Technology { get; set; }
    }
}
