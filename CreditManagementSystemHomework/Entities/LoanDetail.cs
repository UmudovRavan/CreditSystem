namespace CreditManagementSystemHomework.Entities
{
    public class LoanDetail : BaseEntity
    {
        public decimal RemainingDebt { get; set; }
        public DateTime DueDate { get; set; } //son odeme tarixi
        public int LoanId { get; set; }
        public Loan Loan { get; set; }
    }
}
