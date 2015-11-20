using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.SU_Learning_System.Students
{
    class DropoutStudent : Student
    {
        private string dropoutReason;

        public DropoutStudent(string firstName, string lastName, int age,
            int studentNumber, double avgGrade, string dropoutReason) 
            : base(firstName, lastName, age, studentNumber, avgGrade)
        {
            this.DropoutReason = dropoutReason;
        }

        public string DropoutReason
        {
            get
            {
                return this.dropoutReason;
            }

            set
            {
                if (value.Length < 10)
                {
                    throw new ArgumentOutOfRangeException("Drouout reason must have at least 10 characters.");
                }
                this.dropoutReason = value;
            }
        }

        public void Reapply()
        {
            Console.WriteLine("{0} {1}, {2} years old:");
            Console.WriteLine(dropoutReason);
        }
    }
}
