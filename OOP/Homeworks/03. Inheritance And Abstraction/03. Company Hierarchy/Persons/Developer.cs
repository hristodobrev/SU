using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Company_Hierarchy.Persons
{
    using Enumerations;
    using Projects_and_Sales;
    using Interfaces;

    public class Developer : RegularEmployee, IDeveloper
    {
        private List<Project> projects;

        public Developer(string firstName, string lastName, int id,
            decimal salary, Department department, params Project[] projects)
            : base(firstName, lastName, id, salary, department)
        {
            this.projects = new List<Project>();
            foreach (Project project in projects)
            {
                this.Projects.Add(project);
            }
        }

        public List<Project> Projects
        {
            get { return this.projects; }

            set { this.projects = value; }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());

            List<string> projects = new List<string>();
            foreach (Project project in this.Projects)
            {
                projects.Add(project.ToString());
            }

            output.AppendFormat("{0}-Sales:{0}{1}", Environment.NewLine, String.Join("\n", projects));

            return output.ToString();
        }
    }
}
