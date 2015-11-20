using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.SU_Learning_System.Students
{
    class CurrentStudent : Student
    {
        private string currentCourse;

        public CurrentStudent(string firstName, string lastName, int age,
            int studentNumber, double avgGrade, string currentCourse) 
            : base(firstName, lastName, age, studentNumber, avgGrade)
        {
        }

        public string CurrentCourse
        {
            get
            {
                return this.currentCourse;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course name cannot be empty.");
                }
                this.currentCourse = value;
            }
        }
    }
}
