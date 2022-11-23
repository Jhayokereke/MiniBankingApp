using MiniBankingApp.Models;

namespace MiniBankingApp.BusinessLogic
{
    public interface IAccountService
    {
        Account CreateAccount(decimal initialDeposit);
        ICollection<Account> CreateMultipleAccounts(decimal[] initialDeposits);
        bool Deposit(string accountNumber, decimal amount);
        decimal Withdraw(string accountNumber, decimal amount, string transactionPin);
        decimal CheckBalance(string accountNumber, string transactionPin);
        bool Transfer(string sourceAccountNumber, decimal amount, string transactionPin, string destAccountNumber);
        string GenerateStatement(string accountNumber, string transactionPin);
    }
}
