namespace CreditManagementSystemHomework.Models.Loan
{
    public class LoanVM
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
    }
}
