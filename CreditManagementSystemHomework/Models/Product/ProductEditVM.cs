using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CreditManagementSystemHomework.Models.Product
{
    public class ProductEditVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [StringLength(50, ErrorMessage = "Brand cannot exceed 50 characters.")]
        [Required(ErrorMessage = "Brand is required.")]
        public string Brand { get; set; }
        [StringLength(50, ErrorMessage = "Model cannot exceed 50 characters.")]
        [Required(ErrorMessage = "Model is required.")]
        public string BrandModel { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string? ImageUrl { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
