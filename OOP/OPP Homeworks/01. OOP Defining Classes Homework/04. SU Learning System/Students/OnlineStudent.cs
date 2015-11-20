using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.SU_Learning_System.Students
{
    class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName, string lastName, int age,
            int studentNumber, double avgGrade, string currentCourse) 
            : base(firstName, lastName, age, studentNumber, avgGrade, currentCourse)
        {
        }
    }
}
