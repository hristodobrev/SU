using System;

namespace _02.Bank_Of_Kurtovo_Konare.Accounts
{
    using Customers;

    public abstract class Account
    {
        private Customer customer;
        private decimal balance;
        private double interestRate;

        protected Account(Customer customer, decimal balance, double interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer { get; set; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Ballance cannot be negative.");
                }
                this.balance = value;
            }
        }

        public double InterestRate
        {
            get
            {
                return this.interestRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest rate cannot be negative.");
                }
                this.interestRate = value;
            }
        }

        public abstract decimal CalculateInterestForAPeriod(int months);
    }
}
