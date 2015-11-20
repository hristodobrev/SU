using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.SU_Learning_System.Students
{
    class GraduateStudent : Student
    {
        public GraduateStudent(string firstName, string lastName, int age,
            int studentNumber, double avgGrade) 
            : base(firstName, lastName, age, studentNumber, avgGrade)
        {
        }
    }
}
