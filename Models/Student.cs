using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cis174projects.Models
{
    public class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Grade { get; set; }


        public Student(string first, string last, string grade)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Grade = grade;
        }
    }
}
