namespace CreditManagementSystemHomework.Entities
{
    public class Payment : BaseEntity
    {
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public int LoanId { get; set; }
        public Loan Loan { get; set; }
    }
}
