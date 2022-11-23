using MiniBankingApp.Models;

namespace MiniBankingApp.BusinessLogic
{
    public interface IUserService
    {
        BankUser CreateUser(string fname, string lname, string email, string password, decimal initialDeposit);
        bool DeleteUser(string userId);
        bool UpdateUser(BankUser user);
    }
}
