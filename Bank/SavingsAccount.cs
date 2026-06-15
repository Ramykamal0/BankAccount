using System;

namespace Bank
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountNumber, string ownerName)
            : base(accountNumber, ownerName)
        {
        }

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount");
                return;
            }

            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine("Withdraw successful");
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
    }
}