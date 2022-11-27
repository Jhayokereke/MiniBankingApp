using MiniBankingApp.Core.Data;
using MiniBankingApp.Core.Models;
using MiniBankingApp.Core.Models.Enums;
using MiniBankingApp.Core.Utilities;

namespace MiniBankingApp.Core.BusinessLogic
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        private const string CREDIT_DESCRIPTION_TEMPLATE = "CR - Deposit of #amount - #narration - Avail. Bal: #balance";
        private const string DEBIT_DESCRIPTION_TEMPLATE = "DR - Withrawal of #amount - #narration - Avail. Bal: #balance";
        private const string REVERSAL_DESCRIPTION_TEMPLATE = "RVSL - Reversal of #amount - Avail. Bal: #balance";
        public event EventHandler<string>? TransactionCompleted;

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

        public Account CreateAccount(AccountType type, decimal initialDeposit)
        {
            Account newAccount = new Account
            {
                Type = type,
                Balance = initialDeposit,
                TransactionPin = Constants.DEFAULT_TRANSACTION_PIN,
                Number = Generator.GenerateAccountNumber(),
                Transactions = new List<Transaction>()
            };

            newAccount = _accountRepo.Add(newAccount);

            return newAccount;
        }

        public ICollection<Account> CreateMultipleAccounts(decimal[] initialDeposits)
        {
            throw new NotImplementedException();
        }

        public bool Deposit(string accountNumber, decimal amount, string narration = "")
        {
            Account account = _accountRepo.Get(accountNumber);

            if (account == null)
            {
                return false;
            }

            account.Balance += amount;
            account.Transactions.Add(new Transaction
            {
                Type = TransactionType.Credit,
                AccountId = account.Id,
                TransactionTime = DateTime.Now,
                Amount = amount,
                BalanceAfter = account.Balance,
                Description = CREDIT_DESCRIPTION_TEMPLATE.Replace("#amount", amount.ToString()).Replace("#balance", account.Balance.ToString()).Replace("#narration", narration)
            });
            TransactionCompleted?.Invoke(this, "Successful...");
            return _accountRepo.Update(account);
        }

        public void GenerateStatement(string accountNumber, string transactionPin, DateTime from, DateTime to)
        {
            Account account = _accountRepo.Get(accountNumber);

            ICollection<Transaction> transactions = account.Transactions;

            string header = $"Account Statement for {account.Number} {from:dd/MM/yyyy} - {to.Date:dd/MM/yyyy}";

            if (account.TransactionPin == transactionPin)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(header);
                transactions.GenerateStatement(to, from);
                Console.ResetColor();
            }
        }

        public bool Transfer(string sourceAccountNumber, decimal amount, string transactionPin, string destAccountNumber, string narration = "")
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

        public decimal Withdraw(string accountNumber, decimal amount, string transactionPin, string narration = "")
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

            if (account.Balance < 1000)
            {
                return 0;
            }

            account.Transactions.Add(new Transaction
            {
                Type = TransactionType.Credit,
                AccountId = account.Id,
                TransactionTime = DateTime.Now,
                Amount = amount,
                BalanceAfter = account.Balance,
                Description = DEBIT_DESCRIPTION_TEMPLATE.Replace("#amount", amount.ToString()).Replace("#balance", account.Balance.ToString()).Replace("#narration", narration)
            });
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
            account.Transactions.Add(new Transaction
            {
                Type = TransactionType.Credit,
                AccountId = account.Id,
                TransactionTime = DateTime.Now,
                Amount = amount,
                BalanceAfter = account.Balance,
                Description = REVERSAL_DESCRIPTION_TEMPLATE.Replace("#amount", amount.ToString()).Replace("#balance", account.Balance.ToString())
            });
            return _accountRepo.Update(account);
        }

        public bool ChangeTransactionPin(string accountNumber, string oldPin, string newPin)
        {
            Account account = _accountRepo.Get(accountNumber);

            if (account == null || account.TransactionPin != oldPin)
            {
                return false;
            }

            account.TransactionPin = newPin;

            return _accountRepo.Update(account);
        }
    }
}
