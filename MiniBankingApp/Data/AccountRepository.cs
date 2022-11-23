using MiniBankingApp.Models;
using MiniBankingApp.Utilities;

namespace MiniBankingApp.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ICollection<Account> _db;

        public AccountRepository(ICollection<Account> database)
        {
            _db = database;
        }

        public Account Add(Account account)
        {
            account.Id = Generator.GenerateId();
            _db.Add(account);
            account.CreatedOn = DateTime.Now;

            return account;
        }

        public bool Delete(string accountNumber)
        {
            Account accountToDelete = Get(accountNumber);
            if (accountToDelete == null)
            {
                return false;
            }

            return _db.Remove(accountToDelete);
        }

        public Account Get(string accountNumber)
        {
            return _db.FirstOrDefault(x => x.Number == accountNumber);
        }

        public bool Update(Account updatedAccount)
        {
            Account unUpdatedAccount = Get(updatedAccount.Number);

            if (unUpdatedAccount == null)
            {
                return false;
            }

            unUpdatedAccount.TransactionPin = updatedAccount.TransactionPin;
            unUpdatedAccount.Balance = updatedAccount.Balance;
            unUpdatedAccount.ModifiedOn = DateTime.Now;

            return true;
        }
    }
}
