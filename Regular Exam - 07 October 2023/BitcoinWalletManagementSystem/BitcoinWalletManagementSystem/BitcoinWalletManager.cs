namespace BitcoinWalletManagementSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class BitcoinWalletManager : IBitcoinWalletManager
    {
        private List<User> users;
        private List<Wallet> wallets;

        public BitcoinWalletManager()
        {
            this.users = new List<User>();
            this.wallets = new List<Wallet>();
        }

        public void CreateUser(User user)
        {
            this.users.Add(user);
        }

        public void CreateWallet(Wallet wallet)
        {
            this.wallets.Add(wallet);
        }

        public bool ContainsUser(User user)
        {
            return this.users.Contains(user);
        }

        public bool ContainsWallet(Wallet wallet)
        {
            return this.wallets.Contains(wallet);
        }

        public IEnumerable<Wallet> GetWalletsByUser(string userId)
        {
            return this.wallets.Where(wallet => wallet.UserId == userId);
        }

        public void PerformTransaction(Transaction transaction)
        {
            Wallet sender =
                this.wallets.FirstOrDefault(wallet => wallet.Id == transaction.SenderWalletId);
            Wallet receiver =
                this.wallets.FirstOrDefault(wallet => wallet.Id == transaction.ReceiverWalletId);

            if (sender == null || receiver == null || sender.Balance < transaction.Amount)
            {
                throw new ArgumentException();
            }

            sender.Balance -= transaction.Amount;
            receiver.Balance += transaction.Amount;

            sender.AddTransaction(transaction);
            receiver.AddTransaction(transaction);
        }

        public IEnumerable<Transaction> GetTransactionsByUser(string userId)
        {
            Wallet wallet = this.wallets.Find(wallet => wallet.UserId == userId);
            return wallet.GetTransactions();
        }

        public IEnumerable<Wallet> GetWalletsSortedByBalanceDescending()
        {
            return this.wallets.OrderByDescending(wallet => wallet.Balance);
        }

        public IEnumerable<User> GetUsersSortedByBalanceDescending()
        {
            Dictionary<double, User> users = new Dictionary<double, User>();

            foreach (var user in this.users)
            {
                double amount =
                    this.wallets.Where(wallet => wallet.UserId == user.Id).Sum(x => x.Balance);

                users.Add(amount, user);
            }

            return users.OrderByDescending(x => x.Key).Select(x => x.Value);
        }

        public IEnumerable<User> GetUsersByTransactionCount()
        {
            Dictionary<int, User> users = new Dictionary<int, User>();

            foreach (var user in this.users)
            {
                int transactions =
                    this.wallets.Where(wallet => wallet.UserId == user.Id)
                    .Sum(wallet => wallet.GetTransactions().Count());

                users.Add(transactions, user);
            }

            return users.OrderByDescending(x => x.Key).Select(x => x.Value);
        }
    }
}