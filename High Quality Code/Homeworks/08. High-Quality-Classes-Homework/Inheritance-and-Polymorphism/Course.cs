using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public abstract class Course
    {
        private string courseName;
        private string teacherName;
        private IList<string> students;

        protected Course(string courseName, string teacherName, IList<string> students)
        {
            this.CourseName = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string CourseName
        {
            get { return this.courseName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course name cannot be null or empty.");
                }

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get { return this.teacherName; }
            set
            {
                this.teacherName = value;
                
            }
        }

        public IList<string> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            string courseType = this.GetType().Name;

            result.Append(courseType + " { Name = ");
            result.Append(this.CourseName);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }
    }
}
