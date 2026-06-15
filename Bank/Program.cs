using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();
        static List<Transaction> transactions = new List<Transaction>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== BANK SYSTEM =====");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Show Accounts");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Show Transactions");
                Console.WriteLine("7. Exit");

                Console.Write("Choose: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        ShowAccounts();
                        break;
                    case 3:
                        Deposit();
                        break;
                    case 4:
                        Withdraw();
                        break;
                    case 5:
                        Transfer();
                        break;
                    case 6:
                        ShowTransactions();
                        break;
                    case 7:
                        return;
                }
            }
        }

        static void CreateAccount()
        {
            Console.Write("Enter Account Number: ");
            string acc = Console.ReadLine();

            if (accounts.ContainsKey(acc))
            {
                Console.WriteLine("Account already exists!");
                return;
            }

            Console.Write("Enter Owner Name: ");
            string name = Console.ReadLine();

            Console.Write("Type (1 = Savings, 2 = Current): ");
            int type = int.Parse(Console.ReadLine());

            BankAccount account;

            if (type == 1)
                account = new SavingsAccount(acc, name);
            else
                account = new CurrentAccount(acc, name);

            accounts.Add(acc, account);

            Console.WriteLine("Account Created Successfully!");
        }

        static void ShowAccounts()
        {
            foreach (var acc in accounts.Values)
            {
                acc.PrintInfo();
            }
        }

        static BankAccount FindAccount(string accNumber)
        {
            if (accounts.ContainsKey(accNumber))
                return accounts[accNumber];

            return null;
        }

        static void Deposit()
        {
            Console.Write("Enter Account Number: ");
            string acc = Console.ReadLine();

            var account = FindAccount(acc);

            if (account == null)
            {
                Console.WriteLine("Account not found");
                return;
            }

            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            account.Deposit(amount);

            transactions.Add(new Transaction
            {
                FromAccount = acc,
                ToAccount = null,
                Amount = amount,
                Type = "Deposit",
                Date = DateTime.Now
            });
        }

        static void Withdraw()
        {
            Console.Write("Enter Account Number: ");
            string acc = Console.ReadLine();

            var account = FindAccount(acc);

            if (account == null)
            {
                Console.WriteLine("Account not found");
                return;
            }

            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            account.Withdraw(amount);

            transactions.Add(new Transaction
            {
                FromAccount = acc,
                ToAccount = null,
                Amount = amount,
                Type = "Withdraw",
                Date = DateTime.Now
            });
        }

        static void Transfer()
        {
            Console.Write("From Account: ");
            string fromAcc = Console.ReadLine();

            Console.Write("To Account: ");
            string toAcc = Console.ReadLine();

            var from = FindAccount(fromAcc);
            var to = FindAccount(toAcc);

            if (from == null || to == null)
            {
                Console.WriteLine("Invalid accounts");
                return;
            }

            Console.Write("Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            decimal before = from.GetBalance();

            from.Withdraw(amount);

            if (from.GetBalance() == before)
            {
                Console.WriteLine("Transfer failed");
                return;
            }

            to.Deposit(amount);

            transactions.Add(new Transaction
            {
                FromAccount = fromAcc,
                ToAccount = toAcc,
                Amount = amount,
                Type = "Transfer",
                Date = DateTime.Now
            });

            Console.WriteLine("Transfer successful");
        }

        static void ShowTransactions()
        {
            foreach (var t in transactions)
            {
                t.Print();
            }
        }
    }
}