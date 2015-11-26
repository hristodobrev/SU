using System;

namespace _03.Company_Hierarchy.Projects_and_Sales
{
    using Enumerations;
    using Interfaces;
    using System.Text;

    public class Project : IProject
    {
        private static int MINIMUM_ALLOWED_YEAR = 1990;

        private string name;
        private DateTime startDate;
        private string details;
        private State state;
        public Project(string name, DateTime startDate, string details,
            State state)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.Details = details;
            this.State = state;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name of project cannot be empty");
                }
                this.name = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }

            set
            {
                if (value.Year < MINIMUM_ALLOWED_YEAR)
                {
                    throw new ArgumentOutOfRangeException(String.Format("Project date is too old, the minimum allowed year of starting is {0}", MINIMUM_ALLOWED_YEAR));
                }
                this.startDate = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }

            set
            {
                if (value.Trim().Length < 10)
                {
                    throw new ArgumentOutOfRangeException("Details should contain at least 10 characters");
                }
                this.details = value;
            }
        }

        public State State { get; set; }

        public void CloseProject()
        {
            this.State = State.Closed;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(" -Project: {0} [{1}]{2}", this.Name, this.State, Environment.NewLine);
            output.AppendFormat(" -Start date: {0}{1}", this.StartDate, Environment.NewLine);
            output.AppendFormat(" -Details: {0}", this.Details);

            return output.ToString();
        }
    }
}