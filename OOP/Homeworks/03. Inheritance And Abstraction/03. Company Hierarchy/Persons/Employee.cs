using System;
using System.Text;

namespace _03.Company_Hierarchy.Persons
{
    using Enumerations;
    using Interfaces;

    public class Employee : Person, IEmployee
    {
        private decimal salary;
        private Department department;

        public Employee(string firstName, string lastName, int id,
            decimal salary, Department department)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be zero or negative");
                }
                this.salary = value;
            }
        }

        public Department Department { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.AppendFormat("-Salary: {0}{1}", this.Salary, Environment.NewLine);
            output.AppendFormat("-Department: {0}", this.Department);

            return output.ToString();
        }
    }
}
