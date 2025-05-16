using System.ComponentModel.DataAnnotations;

namespace CreditManagementSystemHomework.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public int BranchId { get; set; }
    }
}
