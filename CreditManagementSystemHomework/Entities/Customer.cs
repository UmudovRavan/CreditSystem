namespace CreditManagementSystemHomework.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<Loan> Loan { get; set; }
    }
}
