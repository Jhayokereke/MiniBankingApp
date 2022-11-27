using MiniBankingApp.Core.Models.Enums;

namespace MiniBankingApp.Core.Models
{
    public class Account : BaseEntity
    {
        public AccountType Type { get; set; }
        public string Number { get; set; }
        public string TransactionPin { get; set; }
        public decimal Balance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}