using System;

namespace _01.Persons
{
    class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age) : this(name, age, null)
        {
        }

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.email = email;
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
                    throw new Exception("Name cannot be empty.");
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
                    throw new Exception("Age should be in range [0, 100].");
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
                if (value != null)
                {
                    if (!value.Contains("@"))
                    {
                        throw new Exception("Email should contain @.");
                    }
                }
                this.email = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}: {2}", this.Name, this.Age, this.email ?? "No email");
        }
    }
}
