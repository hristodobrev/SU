using System;
using _04.SU_Learning_System.Exceptions;

namespace _04.SU_Learning_System.Trainers
{
    class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string firstName, string lastName, int age) 
            : base(firstName, lastName, age)
        {
        }

        public void DeleteCourse(string courseName)
        {
            if (this.Courses.Contains(courseName))
            {
                Console.WriteLine("Course {0} has been deleted by {1} {2}.", courseName, this.FirstName, this.LastName);
                this.Courses.Remove(courseName);
            }
            else
            {
                throw new CourseNotFoundException(String.Format("Course {0} doesn't exist.", courseName));
            }
        }
    }
}
