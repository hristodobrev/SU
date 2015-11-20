using System;
using System.Collections.Generic;

namespace _04.SU_Learning_System.Trainers
{
    class Trainer : Person
    {
        private List<string> courses = new List<string>();

        public Trainer(string firstName, string lastName, int age) 
            : base(firstName, lastName, age)
        {
        }

        public void CreateCourse(string courseName)
        {
            Console.WriteLine("Course {0} has been created by {1} {2}.", courseName, this.FirstName, this.LastName);
            this.Courses.Add(courseName);
        }

        public List<string> Courses
        {
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        }
    }
}
