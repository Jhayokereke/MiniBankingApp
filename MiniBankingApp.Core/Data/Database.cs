using MiniBankingApp.Core.BusinessLogic;
using MiniBankingApp.Core.Models;
using MiniBankingApp.Core.Models.Enums;

namespace MiniBankingApp.Core.Data
{
    public static class Database
    {
        public static List<BankUser> BankUsers { get; set; } = new List<BankUser>();
        public static List<Account> Accounts { get; set; } = new List<Account>();

        public static void Seed(IUserService service)
        {
            var user = service.CreateUser("Ademola", "Balogun", "ademola@thebulb.com", "password1", AccountType.Savings, 1200);
            Console.WriteLine($"{user.Firstname} : {user.BankAccounts.First().Number}");
            user = service.CreateUser("Rufai", "Sanni", "rufai@thebulb.com", "password2", AccountType.Savings, 1950);
            Console.WriteLine($"{user.Firstname} : {user.BankAccounts.First().Number}");
            user = service.CreateUser("Chisom", "Iheme", "chisom@thebulb.com", "password6", AccountType.Savings, 1000);
            Console.WriteLine($"{user.Firstname} : {user.BankAccounts.First().Number}");
            user = service.CreateUser("Samson", "Dada", "samson@thebulb.com", "password12", AccountType.Savings, 1300);
            Console.WriteLine($"{user.Firstname} : {user.BankAccounts.First().Number}");
            user = service.CreateUser("Emmanuel", "Ilivieda", "emmanuel@thebulb.com", "password0", AccountType.Savings, 2000);
            Console.WriteLine($"{user.Firstname} : {user.BankAccounts.First().Number}");
            user = service.CreateUser("Fortunate", "Omonuwa", "fortunate@thebulb.com", "password8", AccountType.Savings, 2100);
            Console.WriteLine($"{user.Firstname} : {user.BankAccounts.First().Number}");
            user = service.CreateUser("James", "Olukanni", "james@thebulb.com", "password7", AccountType.Savings, 1500);
            Console.WriteLine($"{user.Firstname} : {user.BankAccounts.First().Number}");
            user = service.CreateUser("Chukwuemeka", "Okereke", "jhay@thebulb.com", "password911", AccountType.Savings, 8500);
            Console.WriteLine($"{user.Firstname} : {user.BankAccounts.First().Number}");
        }
    }
}
