using System.ComponentModel.DataAnnotations;

namespace CreditManagementSystemHomework.Models
{
    public class MerchantVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
    }
}
