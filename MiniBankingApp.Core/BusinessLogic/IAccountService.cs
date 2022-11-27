using MiniBankingApp.Core.Models;
using MiniBankingApp.Core.Models.Enums;

namespace MiniBankingApp.Core.BusinessLogic
{
    public interface IAccountService
    {
        event EventHandler<string> TransactionCompleted;
        Account CreateAccount(AccountType type, decimal initialDeposit);
        ICollection<Account> CreateMultipleAccounts(decimal[] initialDeposits);
        bool Deposit(string accountNumber, decimal amount, string narration);
        decimal Withdraw(string accountNumber, decimal amount, string transactionPin, string narration);
        decimal CheckBalance(string accountNumber, string transactionPin);
        bool Transfer(string sourceAccountNumber, decimal amount, string transactionPin, string destAccountNumber, string narration);
        void GenerateStatement(string accountNumber, string transactionPin, DateTime from, DateTime to);
        bool ChangeTransactionPin(string accountNumber, string oldPin, string newPin);
    }
}
