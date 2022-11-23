using MiniBankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp.Data
{
    internal interface IUserRepository
    {
        BankUser Add(BankUser newUser);
        bool Update(BankUser updatedUser);
        BankUser Get(string id);
        bool Delete(string id);
    }
}
