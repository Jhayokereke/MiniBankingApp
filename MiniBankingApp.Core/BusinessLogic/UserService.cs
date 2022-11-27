using MiniBankingApp.Core.Data;
using MiniBankingApp.Core.Models;
using MiniBankingApp.Core.Models.Enums;

namespace MiniBankingApp.Core.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IAccountService _accountServ;

        public UserService(IUserRepository userRepository, IAccountService accountService)
        {
            _userRepo = userRepository;
            _accountServ = accountService;
        }

        public BankUser CreateUser(string fname, string lname, string email, string password, AccountType type, decimal initialDeposit)
        {
            //create a new user object
            BankUser newUser = new BankUser
            {
                Firstname = fname,
                Lastname = lname,
                Email = email,
                Password = password,
                BankAccounts = new List<Account>()
            };

            //create a new account object
            Account newAccount = _accountServ.CreateAccount(type, initialDeposit);
            //map the account object to the user object
            newUser.BankAccounts.Add(newAccount);
            //add the user object to the database
            newUser = _userRepo.Add(newUser);

            return newUser;
        }

        public bool DeleteUser(string userId)
        {
            return _userRepo.Delete(userId);
        }

        public BankUser GetUserByEmail(string email)
        {
            return _userRepo.GetAll().FirstOrDefault(u => u.Email == email);
        }

        public BankUser GetUserById(string id)
        {
            return _userRepo.GetAll().FirstOrDefault(u => u.Id == id);
        }

        public bool UpdateUser(BankUser user)
        {
            return _userRepo.Update(user);
        }
    }
}
