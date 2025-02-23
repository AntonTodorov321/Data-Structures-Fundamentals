namespace BitcoinWalletManagementSystem
{
    using System.Collections.Generic;

    public interface IBitcoinWalletManager
    {
        void CreateUser(User user);

        void CreateWallet(Wallet wallet);

        bool ContainsUser(User user);

        bool ContainsWallet(Wallet wallet);

        IEnumerable<Wallet> GetWalletsByUser(string userId);

        void PerformTransaction(Transaction transaction);

        IEnumerable<Transaction> GetTransactionsByUser(string userId);

        IEnumerable<Wallet> GetWalletsSortedByBalanceDescending();

        IEnumerable<User> GetUsersSortedByBalanceDescending();

        IEnumerable<User> GetUsersByTransactionCount();
    }
}
