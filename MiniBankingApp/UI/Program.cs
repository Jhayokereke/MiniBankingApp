// See https://aka.ms/new-console-template for more information
using MiniBankingApp.Models;
using System.Numerics;
using System.Text.RegularExpressions;

Console.WriteLine("Welcome to The Bulb banking app.\nClick the 'enter' button to sign up or click 'backspace' to exit the application...");

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
                isValidEmail = ValidateEmail(email);
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

static void SignUp(string email, string password, decimal initialDeposit, string firstname, string lastname)
{
    BankUser user = new BankUser(email, password, initialDeposit)
    {
        Lastname = lastname,
        Firstname = firstname
    };

    //create a user
    //create an account
    //map user to the account

    Console.WriteLine($"New account created for {user.Firstname}");
}

static bool ValidateEmail(string email)
{
    Regex regex = new Regex(@"^[\w-\.]+[\w]@([\w-]+\.)+[\w-]{2,4}$");
    return regex.IsMatch(email);
}

static bool ValidatePassword(string password)
{
    Regex regex = new Regex(@"");
    return regex.IsMatch(password);
}
