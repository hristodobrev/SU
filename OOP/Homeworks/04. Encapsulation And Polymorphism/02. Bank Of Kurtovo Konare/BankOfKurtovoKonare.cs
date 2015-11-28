using System;

namespace _02.Bank_Of_Kurtovo_Konare
{
    using Interfaces;
    using Customers;
    using Accounts;

    class BankOfKurtovoKonare
    {
        static void Main()
        {
            LoanAccount loanAcc1 = new LoanAccount(new IndividualCustomer(), 1000, 7.7);
            LoanAccount loanAcc2 = new LoanAccount(new CompanyCustomer(), 70000, 10.4);
            LoanAccount loanAcc3 = new LoanAccount(new IndividualCustomer(), 5000, 4.2);

            MortgageAccount mortgageAcc1 = new MortgageAccount(new CompanyCustomer(), 75500, 14.1);
            MortgageAccount mortgageAcc2 = new MortgageAccount(new IndividualCustomer(), 3200, 4.7);
            MortgageAccount mortgageAcc3 = new MortgageAccount(new CompanyCustomer(), 19500, 9.2);

            DepositAccount depositAcc1 = new DepositAccount(new CompanyCustomer(), 12000, 6.4);
            DepositAccount depositAcc2 = new DepositAccount(new IndividualCustomer(), 500, 1.2);
            DepositAccount depositAcc3 = new DepositAccount(new IndividualCustomer(), 2300, 3.9);

            Console.WriteLine(loanAcc1.CalculateInterestForAPeriod(2));
            Console.WriteLine(loanAcc2.CalculateInterestForAPeriod(5));
            Console.WriteLine(loanAcc3.CalculateInterestForAPeriod(3));

            Console.WriteLine(loanAcc1.CalculateInterestForAPeriod(4));
            Console.WriteLine(loanAcc2.CalculateInterestForAPeriod(8));
            Console.WriteLine(loanAcc3.CalculateInterestForAPeriod(1));

            //Console.WriteLine(loanAcc1.CalculateInterestForAPeriod(-1));  // this will throw an exception
            Console.WriteLine(loanAcc2.CalculateInterestForAPeriod(7));
            Console.WriteLine(loanAcc3.CalculateInterestForAPeriod(14));
        }
    }
}
