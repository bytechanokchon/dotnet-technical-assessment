namespace Domains.Entities
{
    public class Product
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string UpdatedBy { get; set; }
        public List<ProductImage>? ProductImages { get; set; }
    }
}
