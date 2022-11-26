using MiniBankingApp.Core.Models;

namespace MiniBankingApp.Core.Data
{
    public interface IAccountRepository
    {
        Account Add(Account account);
        bool Update(Account accountToBeUpdated);
        bool Delete(string accountNumber);
        Account Get(string accountNumber);
    }
}
