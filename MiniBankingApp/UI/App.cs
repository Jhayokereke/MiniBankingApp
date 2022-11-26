using MiniBankingApp.Core.BusinessLogic;
using MiniBankingApp.Core.Data;
using MiniBankingApp.Core.Models;
using MiniBankingApp.Core.Utilities;
using System.Globalization;

namespace MiniBankingApp.UI
{
    public class App : IApp
    {
        private readonly IUserService _userServ;
        private readonly IAccountService _accountServ;

        public App(IUserService userService, IAccountService accountService)
        {
            _userServ = userService;
            _accountServ = accountService;
        }

        public void Start()
        {
            Database.Seed(_userServ);
            Console.WriteLine("Welcome to The Bulb banking app.\nClick the 'enter' button to sign up, 'tab' button to login or 'backspace' to exit the application...");

            bool redo = false;
            do
            {
                var keySelected = Console.ReadKey();
                var keyValue = keySelected.Key;

                switch (keyValue)
                {
                    case ConsoleKey.Enter:
                        Console.WriteLine("You have selected the enter key\nProceed to sign up...");
                        Thread.Sleep(1000);
                        Console.Clear();

                        Console.Write("Firstname: ");
                        string firstname = Console.ReadLine();

                        Console.Write("Lastname: ");
                        string lastname = Console.ReadLine();

                        string email;
                        bool isValidEmail;
                        do
                        {
                            Console.Write("Email: ");
                            email = Console.ReadLine();
                            isValidEmail = Validator.ValidateEmail(email);
                            if (!isValidEmail)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("Not a valid email address. Please retry!");
                                Console.ResetColor();
                            }
                        } while (!isValidEmail);

                        Console.Write("Password: ");
                        string password = Console.ReadLine();

                        decimal initialDeposit;
                        bool isNumber;
                        do
                        {
                            Console.Write("Deposit Amount: ");
                            isNumber = decimal.TryParse(Console.ReadLine(), out initialDeposit);
                            if (!isNumber)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("Not a valid amount. Please retry!");
                                Console.ResetColor();
                            }
                        } while (!isNumber);

                        SignUp(email, password, initialDeposit, firstname, lastname);
                        redo = false;
                        break;
                    case ConsoleKey.Tab:
                        Console.WriteLine("You have selected the tab key\nProceed to sign in...");
                        Thread.Sleep(1000);
                        Console.Clear();

                        bool signedIn = false;
                        do
                        {
                            Console.Write("Email: ");
                            email = Console.ReadLine();
                            Console.Write("Password: ");
                            password = Console.ReadLine();

                            if (email != null && password != null)
                            {
                                BankUser? signedInUser = SignIn(email, password);

                                if (signedInUser != null)
                                {
                                    Console.WriteLine("Welcome {0}", signedInUser.Firstname);
                                    LoggedIn(signedInUser);
                                    redo = false;
                                    break;
                                }
                            }

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect email or password!!!");
                            Console.ResetColor();
                        }
                        while (!signedIn);

                        break;
                    case ConsoleKey.Backspace:
                        Console.WriteLine("You have selected the backspace key");
                        redo = false;
                        break;
                    default:
                        Console.WriteLine("I don't understand. Please retry");
                        redo = true;
                        break;
                }
            } while (redo);

            Console.WriteLine("\nGoodbye!");
        }

        private void SignUp(string email, string password, decimal initialDeposit, string firstname, string lastname)
        {
            BankUser user = _userServ.CreateUser(firstname, lastname, email, password, initialDeposit);

            Console.WriteLine($"New account created for {user.Lastname} {user.Firstname}. Account number: {user.BankAccounts.First().Number}.");
        }

        private BankUser? SignIn(string email, string password)
        {
            BankUser user = _userServ.GetUserByEmail(email);

            if (user == null || user.Password != password)
            {
                return null;
            }

            return user;
        }

        private void LoggedIn(BankUser user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("What will you like to do next?" +
                "\nClick one of the following keys to perform an action:" +
                "\n'D' - To make a deposit" +
                "\n'W' - To make a Withdrawal" +
                "\n'T' - To make a Transfer" +
                "\n'S' - To print your statement" +
                "\n'N' - To open a new account" +
                "\n'ESC' - To Logout");
            var key = Console.ReadKey().Key;
            Console.WriteLine();
            Thread.Sleep(500);

            switch(key)
            {
                case ConsoleKey.D:
                    Console.Write("Account to credit: ");
                    var accountNumber = Console.ReadLine();
                    Console.Write("Amount: ");
                    var amount = decimal.Parse(Console.ReadLine());
                    Console.Write("Narration: ");
                    var narration = Console.ReadLine();

                    Console.WriteLine(string.Format(new CultureInfo("en-NG"), "Attempting to deposit {0:c2} to {1}. Click Enter to confirm!", amount, accountNumber));
                    if (Console.ReadKey().Key != ConsoleKey.Enter)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Cancelled...");
                        Console.ResetColor();
                    }
                    else
                    {
                        var success = _accountServ.Deposit(accountNumber, amount, narration);
                        if (success)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Successful...");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Failed...");
                            Console.ResetColor();
                        }
                    }
                    LoggedIn(user);
                    break;
                case ConsoleKey.W:
                    break;
                case ConsoleKey.T:
                    break;
                case ConsoleKey.S:
                    Console.Write("Target account: ");
                    accountNumber = Console.ReadLine();
                    Console.Write("Transaction pin: ");
                    var transactionPin = Console.ReadLine();
                    Console.Write("Start date: ");
                    var from = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yy", CultureInfo.InvariantCulture);
                    Console.Write("End date: ");
                    var to = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yy", CultureInfo.InvariantCulture);
                    _accountServ.GenerateStatement(accountNumber, transactionPin, from, to);
                    break;
                case ConsoleKey.N:
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    Console.WriteLine("Sorry! I do not understand...");
                    LoggedIn(user);
                    break;
            }
        }
    }
}
