using System;

namespace _02.Bank_Of_Kurtovo_Konare.Accounts
{
    using Customers;
    using Interfaces;

    public class LoanAccount : Account, ILoanAccount
    {
        public LoanAccount(Customer customer, decimal balance, double interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public void Deposit(decimal ammount)
        {
            this.Balance += ammount;
        }

        public override decimal CalculateInterestForAPeriod(int months)
        {
            if (months < 0)
            {
                throw new ArgumentOutOfRangeException("Months cannot be negative number.");
            }

            if (this.Customer is IndividualCustomer)
            {
                if (months < 3)
                {
                    return 0;
                }

                return this.Balance * (decimal)(1 + this.InterestRate * (double)months);
            }

            if (months < 2)
            {
                return 0;
            }

            return this.Balance * (decimal)(1 + this.InterestRate * (double)months);
        }
    }
}
