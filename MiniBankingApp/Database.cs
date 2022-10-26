using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp
{
    public class Database
    {
        public Database()
        {
            BankUsers = new List<BankUser>()
            {
                new BankUser("ademola@thebulb.africa", "dgtughkchg")
                {
                    Firstname = "Ademola",
                    Lastname = "Balogun",
                    BankAccount = new Account(20000)
                },
                new BankUser("fortunate@thebulb.africa", "dgtughkchg")
                {
                    Firstname = "Fortunate",
                    Lastname = "Omonuwa",
                    BankAccount = new Account(1000)
                },
                new BankUser("samson@thebulb.africa", "dgtughkchg")
                {
                    Firstname = "Samson",
                    Lastname = "Dada",
                    BankAccount = new Account(15200)
                },
                new BankUser("chisom@thebulb.africa", "dgtughkchg")
                {
                    Firstname = "Chisom",
                    Lastname = "Iheme",
                    BankAccount = new Account(200)
                },
                new BankUser("james@thebulb.africa", "dgtughkchg")
                {
                    Firstname = "James",
                    Lastname = "Olukanni",
                    BankAccount = new Account()
                },
                new BankUser("emmanuel@thebulb.africa", "dgtughkchg")
                {
                    Firstname = "Emmanuel",
                    Lastname = "Ilivieda",
                    BankAccount = new Account(7000)
                }
            };
        }
        public List<BankUser> BankUsers { get; set; }
    }
}
