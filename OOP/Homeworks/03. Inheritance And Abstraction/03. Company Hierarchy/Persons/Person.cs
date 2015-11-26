using System;
using System.Text;

namespace _03.Company_Hierarchy.Persons
{
    using Interfaces;

    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;
        private int id;

        protected Person(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be empty");
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
                    throw new ArgumentNullException("Last name cannot be empty");
                }
                this.lastName = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value < 10000 || value > 999999999)
                {
                    throw new ArgumentOutOfRangeException("Id should be 5-9 digits long");
                }
                this.id = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("-Type: {0}{1}", this.GetType().Name, Environment.NewLine);
            output.AppendFormat("-ID: #{0}{1}", this.Id, Environment.NewLine);
            output.AppendFormat("-Name: {0} {1}{2}", this.FirstName, this.LastName, Environment.NewLine);

            return output.ToString();
        }
    }
}
