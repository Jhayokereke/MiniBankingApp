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
                new BankUser("ademola@thebulb.africa", "dgtughkchg", 2000)
                {
                    Firstname = "Ademola",
                    Lastname = "Balogun"
                },
                new BankUser("fortunate@thebulb.africa", "dgtughkchg", 1000)
                {
                    Firstname = "Fortunate",
                    Lastname = "Omonuwa"
                },
                new BankUser("samson@thebulb.africa", "dgtughkchg", 15200)
                {
                    Firstname = "Samson",
                    Lastname = "Dada"
                },
                new BankUser("chisom@thebulb.africa", "dgtughkchg", 200)
                {
                    Firstname = "Chisom",
                    Lastname = "Iheme"
                },
                new BankUser("james@thebulb.africa", "dgtughkchg", 1000)
                {
                    Firstname = "James",
                    Lastname = "Olukanni"
                },
                new BankUser("emmanuel@thebulb.africa", "dgtughkchg", 300)
                {
                    Firstname = "Emmanuel",
                    Lastname = "Ilivieda"
                }
            };
        }
        public List<BankUser> BankUsers { get; set; }
    }
}
