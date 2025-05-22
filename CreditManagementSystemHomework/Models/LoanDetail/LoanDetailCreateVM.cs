using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CreditManagementSystemHomework.Models.LoanDetail
{
    public class LoanDetailCreateVM
    {
        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Remaining debt is required.")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Remaining debt cannot be negative.")]
        public decimal RemainingDebt { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(20, ErrorMessage = "Status cannot be longer than 20 characters.")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Loan selection is required.")]
        public int LoanId { get; set; }
        public List<SelectListItem> Loans { get; set; } = new List<SelectListItem>();
    }
}
