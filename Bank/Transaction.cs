using System;

namespace Bank
{
    public class Transaction
    {
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Date} | {Type} | From: {FromAccount} | To: {ToAccount} | Amount: {Amount}");
        }
    }
}