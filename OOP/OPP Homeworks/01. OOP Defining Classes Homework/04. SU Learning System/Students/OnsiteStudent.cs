using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.SU_Learning_System.Students
{
    class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisits;

        public OnsiteStudent(string firstName, string lastName, int age,
            int studentNumber, double avgGrade, string currentCourse, int numberOfVisits) 
            : base(firstName, lastName, age, studentNumber, avgGrade, currentCourse)
        {
            this.NumberOfVisits = numberOfVisits;
        }

        public int NumberOfVisits
        {
            get
            {
                return this.numberOfVisits;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Number of visits cannot be negative.");
                }
                this.numberOfVisits = value;
            }
        }
    }
}
