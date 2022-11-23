using MiniBankingApp.Models;
using MiniBankingApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ICollection<BankUser> _db;

        public UserRepository(ICollection<BankUser> database)
        {
            _db = database;
        }

        public BankUser Add(BankUser newUser)
        {
            newUser.Id = Generator.GenerateId();
            newUser.CreatedOn = DateTime.Now;
            _db.Add(newUser);

            return newUser;
        }

        public bool Delete(string id)
        {
            BankUser userToDelete = Get(id);
            if (userToDelete == null)
            {
                return false;
            }

            return _db.Remove(userToDelete);
        }

        public BankUser Get(string id)
        {
            return _db.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<BankUser> GetAll()
        {
            return _db;
        }

        public bool Update(BankUser updatedUser)
        {
            BankUser unUpdatedUser = Get(updatedUser.Id);

            if (unUpdatedUser == null)
            {
                return false;
            }

            unUpdatedUser.Firstname = updatedUser.Firstname;
            unUpdatedUser.Lastname = updatedUser.Lastname;
            unUpdatedUser.Email = updatedUser.Email;
            unUpdatedUser.Password = updatedUser.Password;
            unUpdatedUser.Address = updatedUser.Address;
            unUpdatedUser.BankAccounts = updatedUser.BankAccounts;
            unUpdatedUser.ModifiedOn = DateTime.Now;

            return true;
        }
    }
}
