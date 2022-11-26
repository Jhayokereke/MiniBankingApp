using MiniBankingApp.Core.Models;

namespace MiniBankingApp.Core.Data
{
    public interface IUserRepository
    {
        BankUser Add(BankUser newUser);
        bool Update(BankUser updatedUser);
        BankUser Get(string id);
        bool Delete(string id);
        ICollection<BankUser> GetAll();
    }
}
