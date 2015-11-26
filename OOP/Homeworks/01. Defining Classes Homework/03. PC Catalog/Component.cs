using System;
using System.Text;
using System.Globalization;

namespace _03.PC_Catalog
{
    class Component
    {
        private string name;
        private string details;
        private decimal price;

        public Component(string name, decimal price)
            : this(name, null, price)
        {

        }

        public Component(string name, string details, decimal price)
        {
            this.Name = name;
            this.Details = details;
            this.Price = price;
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
                    throw new ArgumentNullException("Name cannot be empty.");
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be positive number.");
                }
                this.price = value;
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
                this.details = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.name);

            if (!String.IsNullOrEmpty(this.Details))
	        {
		            sb.Append(": " + this.Details);
	        }
            sb.Append(String.Format(" - {0}", this.Price.ToString("C", CultureInfo.CreateSpecificCulture("bg-BG"))));

            return sb.ToString();
        }
    }
}
