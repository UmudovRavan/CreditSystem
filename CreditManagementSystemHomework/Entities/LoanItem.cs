namespace CreditManagementSystemHomework.Entities
{
    public class LoanItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int LoanId { get; set; }
        public int ProductId { get; set; }
        public Loan Loan { get; set; }
        public Product Product { get; set; }
    }
}
