using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp.Models
{
    public class BankUser : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; } = new Address();
        public ICollection<Account> BankAccounts { get; set; }
    }
}
