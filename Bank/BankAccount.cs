using System;

namespace Bank
{
    public abstract class BankAccount
    {
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }

        protected decimal Balance;

        public BankAccount(string accountNumber, string ownerName)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = 0;
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit amount");
                return;
            }

            Balance += amount;
            Console.WriteLine("Deposit successful");
        }

        public abstract void Withdraw(decimal amount);

        public void PrintInfo()
        {
            Console.WriteLine($"Account: {AccountNumber} | Owner: {OwnerName} | Balance: {Balance}");
        }
    }
}