namespace BitcoinWalletManagementSystem
{
    using System;
    using System.Collections.Generic;

    public class Wallet : IComparable<Wallet>
    {
        private List<Transaction> transactions;

        public Wallet()
        {
            this.transactions = new List<Transaction>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public long Balance { get; set; }

        public void AddTransaction(Transaction transaction)
        {
            this.transactions.Add(transaction);
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return this.transactions;
        }

        public int CompareTo(Wallet other)
        {
            return this.transactions.Count.CompareTo(other.transactions.Count);
        }
    }
}