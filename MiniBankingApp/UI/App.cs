using MiniBankingApp.BusinessLogic;
using MiniBankingApp.Models;
using MiniBankingApp.Utilities;
using System.Text.RegularExpressions;

namespace MiniBankingApp.UI
{
    public class App
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
                                signedIn = true;

                                if (signedInUser != null)
                                {
                                    LoggedIn(signedInUser);
                                    redo = false;
                                    break;
                                }
                            }

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect email or password!!!");
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

            if(user.Password != password)
            {
                return null;
            }

            return user;
        }

        private void LoggedIn(BankUser user)
        {
            Console.WriteLine("");
        }
    }
}
