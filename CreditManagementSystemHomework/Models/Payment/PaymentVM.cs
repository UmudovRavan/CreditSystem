namespace CreditManagementSystemHomework.Models.Payment
{
    public class PaymentVM
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public int LoanId { get; set; }
    }
}
