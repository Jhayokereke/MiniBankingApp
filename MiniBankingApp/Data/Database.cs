using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniBankingApp.Models;

namespace MiniBankingApp.Data
{
    public static class Database
    {
        static Database()
        {
            BankUsers = new List<BankUser>()
            {
                new BankUser()
                {
                    Firstname = "Ademola",
                    Lastname = "Balogun",
                    Email = "ademola@thebulb.africa"
                },
                new BankUser()
                {
                    Firstname = "Fortunate",
                    Lastname = "Omonuwa",
                    Email = "fortunate@thebulb.africa"
                },
                new BankUser()
                {
                    Firstname = "Samson",
                    Lastname = "Dada",
                    Email = "samson@thebulb.africa"
                },
                new BankUser()
                {
                    Firstname = "Chisom",
                    Lastname = "Iheme"
                },
                new BankUser()
                {
                    Firstname = "James",
                    Lastname = "Olukanni"
                },
                new BankUser()
                {
                    Firstname = "Emmanuel",
                    Lastname = "Ilivieda"
                }
            };
        }
        public static List<BankUser> BankUsers { get; set; }
        public static List<Account> Accounts { get; set; }
    }
}
