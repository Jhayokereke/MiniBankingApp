using MiniBankingApp.Core.Models;
using MiniBankingApp.Core.Utilities;

namespace MiniBankingApp.Core.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ICollection<Account> _db;

        public AccountRepository()
        {
            _db = Database.Accounts;
        }

        public Account Add(Account account)
        {
            account.Id = Generator.GenerateId();
            account.CreatedOn = DateTime.Now;
            _db.Add(account);

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
