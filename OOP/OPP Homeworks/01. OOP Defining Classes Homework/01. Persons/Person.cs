using System;

namespace _01.Persons
{
    class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age)
            : this(name, age, null)
        {
        }

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty.");
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
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException("Age should be in range [0, 100].");
                }
                this.age = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (!String.IsNullOrEmpty(value) && !value.Contains("@"))
                {
                    throw new ArgumentException("Email must contain \"@\".");
                }
                this.email = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Age: {1}, Email: {2}", this.Name, this.Age, String.IsNullOrEmpty(this.Email) ? "No email" : this.Email);
        }
    }
}
