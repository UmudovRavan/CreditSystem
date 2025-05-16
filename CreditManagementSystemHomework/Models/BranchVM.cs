using System.ComponentModel.DataAnnotations;

namespace CreditManagementSystemHomework.Models
{
    public class BranchVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int MerchantId { get; set; }
    }
}
