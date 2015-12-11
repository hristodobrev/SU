namespace _04.Student_Class
{
    public class Student
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        private int age;
        
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.PropertyChanged != null)
                {
                    PropertyChangedEventArgs args = new PropertyChangedEventArgs("Name", this.Name, value);
                    this.PropertyChanged(this, args);
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (this.PropertyChanged != null)
                {
                    PropertyChangedEventArgs args = new PropertyChangedEventArgs("Age", this.Age, value);
                    this.PropertyChanged(this, args);
                }
                this.age = value;
            }
        }
    }
}
