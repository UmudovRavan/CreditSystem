namespace CreditManagementSystemHomework.Entities
{
    public class Loan : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public LoanDetail LoanDetail { get; set; }
        public ICollection<LoanItem> LoanItems { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
