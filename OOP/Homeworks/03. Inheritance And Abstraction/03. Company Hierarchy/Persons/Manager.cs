using System;
using System.Text;
using System.Collections.Generic;

namespace _03.Company_Hierarchy.Persons
{
    using Enumerations;
    using Interfaces;

    public class Manager : Employee, IManager
    {
        private List<Employee> employees;

        public Manager(string firstName, string lastName, int id,
            decimal salary, Department department, params Employee[] employees)
            : base(firstName, lastName, id,
            salary, department)
        {
            this.employees = new List<Employee>();
            foreach (Employee employee in employees)
            {
                this.Employees.Add(employee);
            }
        }

        public List<Employee> Employees
        {
            get { return this.employees; }
            set { this.employees = value; }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());

            List<string> employees = new List<string>();
            foreach (Employee employee in this.Employees)
            {
                employees.Add(employee.FirstName + " " + employee.LastName);
            }

            output.AppendFormat("{0}-Employees under command: {1}", Environment.NewLine, String.Join(", ", employees));

            return output.ToString();
        }
    }
}
