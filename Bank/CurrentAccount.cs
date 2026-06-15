using System;

namespace Bank
{
    public class CurrentAccount : BankAccount
    {
        private decimal overdraftLimit = 1000;

        public CurrentAccount(string accountNumber, string ownerName)
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

            if (Balance - amount >= -overdraftLimit)
            {
                Balance -= amount;
                Console.WriteLine("Withdraw successful");
            }
            else
            {
                Console.WriteLine("Overdraft limit exceeded");
            }
        }
    }
}