namespace CreditManagementSystemHomework.Models.Product
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string BrandModel { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
