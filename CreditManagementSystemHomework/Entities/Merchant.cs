namespace CreditManagementSystemHomework.Entities
{
    public class Merchant:BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
}
