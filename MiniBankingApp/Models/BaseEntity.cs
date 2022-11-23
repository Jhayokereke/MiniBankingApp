namespace MiniBankingApp.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
