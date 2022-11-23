using MiniBankingApp.Data;
using MiniBankingApp.Models;
using MiniBankingApp.Utilities;

namespace MiniBankingApp.BusinessLogic
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepo = accountRepository;
        }

        public decimal CheckBalance(string accountNumber, string transactionPin)
        {
            Account account = _accountRepo.Get(accountNumber);

            //check if transaction pin matches the given account
            if (account.TransactionPin == transactionPin)
            {
                return account.Balance;
            }

            return -1;
        }

        public Account CreateAccount(decimal initialDeposit)
        {
            Account newAccount = new Account
            {
                Balance = initialDeposit,
                TransactionPin = Constants.DEFAULT_TRANSACTION_PIN,
                Number = Generator.GenerateAccountNumber(),
                Transactions = new List<string>()
            };

            newAccount = _accountRepo.Add(newAccount);

            return newAccount;
        }

        public ICollection<Account> CreateMultipleAccounts(decimal[] initialDeposits)
        {
            throw new NotImplementedException();
        }

        public bool Deposit(string accountNumber, decimal amount)
        {
            Account account = _accountRepo.Get(accountNumber);

            if (account == null)
            {
                return false;
            }

            account.Balance += amount;
            account.Transactions.Add($"CR - {DateTime.Now} - Deposit of {amount:c2}.");
            return _accountRepo.Update(account);
        }

        public string GenerateStatement(string accountNumber, string transactionPin)
        {
            Account account = _accountRepo.Get(accountNumber);

            ICollection<string> transactions = account.Transactions;

            string statement = $"Account Statement for {account.Number}";

            foreach (string transaction in transactions)
            {
                statement += $"\n{transaction}";
            }

            return statement;
        }

        public bool Transfer(string sourceAccountNumber, decimal amount, string transactionPin, string destAccountNumber)
        {
            //withdraw from source
            decimal amountToTransfer = Withdraw(sourceAccountNumber, amount, transactionPin);

            if (amountToTransfer == 0)
            {
                return false;
            }

            //deposit to destination
            bool success = Deposit(destAccountNumber, amountToTransfer);

            if (!success)
            {
                bool reversed;
                do
                {
                    reversed = Reversal(sourceAccountNumber, amountToTransfer);
                }
                while (!reversed);
                return success;
            }

            return success;
        }

        public decimal Withdraw(string accountNumber, decimal amount, string transactionPin)
        {
            Account account = _accountRepo.Get(accountNumber);

            //check if requested account exists
            //check if transaction pin matches
            //check if balance is greater than or equal to amount
            if (account == null || account.TransactionPin != transactionPin || account.Balance < amount)
            {
                return 0;
            }

            account.Balance -= amount;
            account.Transactions.Add($"DR - {DateTime.Now} - Withdrawal of {amount:c2}.");
            bool updated = _accountRepo.Update(account);

            if (!updated)
            {
                return 0;
            }

            return amount;
        }

        private bool Reversal(string accountNumber, decimal amount)
        {
            Account account = _accountRepo.Get(accountNumber);

            if (account == null)
            {
                return false;
            }

            account.Balance += amount;
            account.Transactions.Add($"RVSL - {DateTime.Now} - Reversal of {amount:c2}.");
            return _accountRepo.Update(account);
        }
    }
}
