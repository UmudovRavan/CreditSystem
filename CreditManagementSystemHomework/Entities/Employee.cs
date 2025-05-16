namespace CreditManagementSystemHomework.Entities
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public ICollection<Loan> Loan { get; set; }
    }
}
