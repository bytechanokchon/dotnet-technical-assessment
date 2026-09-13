namespace Applications.DTOs.Products
{
    public class ProductDto
    {
        public required string ProductId { get; set; }
        public required string ProductName { get; set; }
        public required string ProductDescription { get; set; }
        public required decimal Price { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string UpdatedBy { get; set; }
        public List<ProductImageDto>? Images { get; set; }
    }
}
