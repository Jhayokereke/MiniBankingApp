using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp.Data
{
    public class AccountRepository : IAccountRepository
    {
        public Account Add(BankUser user, decimal initialDeposit)
        {
            //create the account
            //link the account to the owner
            user.BankAccount = new Account(initialDeposit);
            //add to database
            Database.
            //return the created account
        }

        public bool Delete(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public Account Get(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public bool Update(Account accountToBeUpdated)
        {
            throw new NotImplementedException();
        }
    }

    public interface IAccountRepository
    {
        Account Add(BankUser user, decimal initialDeposit);
        bool Update(Account accountToBeUpdated);
        bool Delete(string accountNumber);
        Account Get(string accountNumber);
    }
}
