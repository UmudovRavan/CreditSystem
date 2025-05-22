namespace CreditManagementSystemHomework.Entities
{
    public class LoanDetail : BaseEntity
    {
        public decimal Amount { get; set; }
        public decimal RemainingDebt { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int LoanId { get; set; }
        public Loan Loan { get; set; }
    }
}
