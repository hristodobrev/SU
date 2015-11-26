using System;
using System.Text;

namespace _03.Company_Hierarchy.Persons
{
    using Interfaces;
    public class Customer : Person, ICustomer
    {
        private decimal totalAmount;
        public Customer(string firstName, string lastName, int id, decimal totalAmount)
            : base(firstName, lastName, id)
        {
            this.TotalAmount = totalAmount;
        }
        public decimal TotalAmount
        {
            get
            {
                return this.totalAmount;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Total amount cannot be zero or negative");
                }
                this.totalAmount = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.AppendFormat("-Total Amount: {0}", this.TotalAmount);
            return output.ToString();
        }
    }
}
