using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp
{
    public class BankUser
    {
        public BankUser(string email, string password, decimal initialDeposit)
        {
            Email = email;
            Password = password;
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; } = new Address();
        public Account BankAccount { get; set; }
    }
}
