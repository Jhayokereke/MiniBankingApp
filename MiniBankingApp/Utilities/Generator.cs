using MiniBankingApp.Models;
using System.Text;

namespace MiniBankingApp.Utilities
{
    public static class Generator
    {
        public static string GenerateId()
        {
            return Guid.NewGuid().ToString()[..20];
        }

        public static string GenerateAccountNumber()
        {
            return $"08{DateTime.Today:yyMMdd}{new Random().Next(0, 99).ToString().PadLeft(2,'0')}";
        }
    }
}
