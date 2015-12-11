namespace _01.Custom_Linq_Extension_Methods
{
    public class Student
    {
        public Student(string name, int grade)
        {
            this.Name = name;
            this.Grade = grade;
        }

        public string Name { get; private set; }

        public int Grade { get; private set; }
    }
}
