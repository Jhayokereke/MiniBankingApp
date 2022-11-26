using MiniBankingApp.Core.Models;

namespace MiniBankingApp.Core.BusinessLogic
{
    public interface IUserService
    {
        BankUser CreateUser(string fname, string lname, string email, string password, decimal initialDeposit);
        bool DeleteUser(string userId);
        bool UpdateUser(BankUser user);
        BankUser GetUserByEmail(string email);
        BankUser GetUserById(string Id);
    }
}
