using MiniBankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp.BusinessLogic
{
    public class UserService : IUserService
    {
        public UserService()
        {

        }
        public BankUser CreateUser(string fname, string lname, string email, string password)
        {
            BankUser newUser = new BankUser
            {
                Firstname = fname,
                Lastname = lname,
                Email = email,
                Password = password,
                BankAccounts = new List<Account>()
            };


        }

        public bool DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(BankUser user)
        {
            throw new NotImplementedException();
        }
    }

    public interface IUserService
    {
        BankUser CreateUser(string fname, string lname, string email, string password);
        bool DeleteUser(string userId);
        bool UpdateUser(BankUser user);
    }
}
