using System.Text.RegularExpressions;

namespace MiniBankingApp.Core.Utilities
{
    public static class Validator
    {
        public static bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^[\w-\.]+[\w]@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }

        public static bool ValidatePassword(string password)
        {
            Regex regex = new(@"");
            return regex.IsMatch(password);
        }
    }
}
