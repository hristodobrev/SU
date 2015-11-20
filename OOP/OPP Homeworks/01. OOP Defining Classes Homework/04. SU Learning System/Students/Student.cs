using System;

namespace _04.SU_Learning_System.Students
{
    class Student : Person
    {
        private int studentNumber;
        private double averageGrade;

        public Student(string firstName, string lastName, int age,
            int studentNumber, double avgGrade) 
            : base(firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = avgGrade;
        }

        public int StudentNumber
        {
            get
            {
                return this.studentNumber;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Student number cannot be negative.");
                }
                this.studentNumber = value;
            }
        }

        public double AverageGrade
        {
            get
            {
                return this.averageGrade;
            }

            set
            {
                if (value < 2.0 || value > 6.0)
                {
                    throw new ArgumentOutOfRangeException("Grade should be in range [2.00..6.00].");
                }
                this.averageGrade = value;
            }
        }
    }
}
