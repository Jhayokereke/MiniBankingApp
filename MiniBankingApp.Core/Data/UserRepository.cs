using MiniBankingApp.Core.Models;
using MiniBankingApp.Core.Utilities;

namespace MiniBankingApp.Core.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ICollection<BankUser> _db;

        public UserRepository()
        {
            _db = Database.BankUsers;
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
