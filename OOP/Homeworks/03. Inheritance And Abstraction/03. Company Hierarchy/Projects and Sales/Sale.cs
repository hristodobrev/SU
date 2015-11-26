using System;

namespace _03.Company_Hierarchy.Projects_and_Sales
{
    using Interfaces;
    using System.Text;
    public class Sale : ISale
    {
        private static int MINIMUM_ALLOWED_YEAR = 2000;

        private string productName;
        private DateTime date;
        decimal price;

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Product name cannot be empty");
                }
                this.productName = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                if (value.Year < MINIMUM_ALLOWED_YEAR)
                {
                    throw new ArgumentOutOfRangeException(String.Format("Year date of the product cannot be less than {0}", MINIMUM_ALLOWED_YEAR));
                }
                this.date = value;
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
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price of the product cannot be zero or negative");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(" -Product Name: {0}{1}", this.ProductName, Environment.NewLine);
            output.AppendFormat(" -Date: {0}{1}", this.Date, Environment.NewLine);
            output.AppendFormat(" -Price: {0}", this.Price);
            
            return output.ToString();
        }
    }
}
