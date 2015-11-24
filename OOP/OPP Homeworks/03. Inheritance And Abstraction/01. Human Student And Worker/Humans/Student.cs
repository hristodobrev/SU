using System;

namespace _01.Human_Student_And_Worker
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (value.Trim().Length < 5 || value.Trim().Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Faculty number must contain 5-10 digits and letters");
                }
                this.facultyNumber = value;
            }
        }
    }
}
