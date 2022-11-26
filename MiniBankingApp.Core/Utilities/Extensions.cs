using ConsoleTables;
using MiniBankingApp.Core.Models;

namespace MiniBankingApp.Core.Utilities
{
    public static class Extensions
    {
        public static void GenerateStatement(this ICollection<Transaction> transactions, DateTime? to, DateTime? from)
        {
            DateTime? start = from;
            DateTime end = to ?? DateTime.Today;
            if (start != null)
            {
                //filter start point
                transactions = transactions.Where(t => t.TransactionTime.Date >= start?.Date).ToList();
            }
            //filter end point
            transactions = transactions.Where(t => t.TransactionTime.Date <= end.Date).ToList();

            ConsoleTable table = new("Time", "Type", "Amount", "Description", "Balance");
            foreach(var tran in transactions)
            {
                table.AddRow(tran.TransactionTime, tran.Type, tran.Amount, tran.Description, tran.BalanceAfter);
            }
            table.Write(Format.Alternative);
        }
    }
}
