using MiniBankingApp.Core.Models;
using MiniBankingApp.Core.Models.Enums;

namespace MiniBankingApp.Core.BusinessLogic
{
    public interface IUserService
    {
        BankUser CreateUser(string fname, string lname, string email, string password, AccountType type, decimal initialDeposit);
        bool DeleteUser(string userId);
        bool UpdateUser(BankUser user);
        BankUser GetUserByEmail(string email);
        BankUser GetUserById(string Id);
    }
}
