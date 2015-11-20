using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.SU_Learning_System
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName {
            get
            {
                return this.firstName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be empty.");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be empty.");
                }
                this.lastName = value;
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
                    throw new ArgumentOutOfRangeException("Age should be in range [1..100]");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Name: {0} {1}, Age: {2}", this.FirstName, this.LastName, this.Age);
        }
    }
}
