// See https://aka.ms/new-console-template for more information
using MiniBankingApp;

Console.WriteLine("Welcome to The Bulb banking app.\nClick the 'enter' button to sign up or click 'backspace' to exit the application...");

bool redo = false;
do
{
    var keySelected = Console.ReadKey();
    var keyValue = keySelected.Key;

    switch (keyValue)
    {
        case ConsoleKey.Enter:
            Console.WriteLine("You have selected the enter key\nProceed to sign Up");
            Console.Clear();
            Console.Write("Firstname: ");
            string firstname = Console.ReadLine();
            Console.Write("Lastname: ");
            string lastname = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Deposit Amount: ");
            decimal initialDeposit = decimal.Parse(Console.ReadLine());
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


void SignUp(string email, string password, decimal initialDeposit, string firstname, string lastname)
{
    BankUser user = new BankUser(email, password, initialDeposit)
    {
        Lastname = lastname,
        Firstname = firstname
    };

    Console.WriteLine($"New account created for {user.Firstname}");
}


