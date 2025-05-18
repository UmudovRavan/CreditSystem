using System.ComponentModel.DataAnnotations;

namespace CreditManagementSystemHomework.Models.Customer
{
    public class CustomerCreateVM
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Identity number is required.")]
        public string IdentityNumber { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
        public string Address { get; set; }
    }
}
