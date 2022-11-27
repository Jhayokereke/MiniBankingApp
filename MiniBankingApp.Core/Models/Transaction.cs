using MiniBankingApp.Core.Models.Enums;

namespace MiniBankingApp.Core.Models
{
    public class Transaction : BaseEntity
    {
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public DateTime TransactionTime { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfter { get; set; }
        public string AccountId { get; set; }
    }
}
