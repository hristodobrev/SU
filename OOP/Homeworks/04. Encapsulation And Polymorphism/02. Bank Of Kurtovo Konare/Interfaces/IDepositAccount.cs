using System;

namespace _02.Bank_Of_Kurtovo_Konare.Interfaces
{
    public interface IDepositAccount
    {
        void Deposit(decimal ammount);

        void Withdraw(decimal ammount);
    }
}
