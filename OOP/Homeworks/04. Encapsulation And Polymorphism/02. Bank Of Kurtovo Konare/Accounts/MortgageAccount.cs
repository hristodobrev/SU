using System;

namespace _02.Bank_Of_Kurtovo_Konare.Accounts
{
    using Customers;
    using Interfaces;

    public class MortgageAccount : Account, IMortgageAccount
    {
        public MortgageAccount(Customer customer, decimal balance, double interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public void Deposit(decimal ammount)
        {
            this.Balance += ammount;
        }

        public override decimal CalculateInterestForAPeriod(int months)
        {
            if (this.Customer is CompanyCustomer)
            {
                if (months < 12)
                {
                    return (this.Balance * (decimal)(1 + this.InterestRate * (double)months)) / 2;
                }

                return this.Balance * (decimal)(1 + this.InterestRate * (double)months);                
            }

            if (months < 6)
            {
                return 0;
            }

            return this.Balance * (decimal)(1 + this.InterestRate * (double)months);
        }
    }
}
