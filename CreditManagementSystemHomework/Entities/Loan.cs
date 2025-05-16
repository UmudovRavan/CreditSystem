namespace CreditManagementSystemHomework.Entities
{
    public class Loan : BaseEntity
    {
        public DateTime CreditCreateTime { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public LoanDetail LoanDetail { get; set; }
        public ICollection<LoanItem> LoanItems { get; set; }
    }
}
