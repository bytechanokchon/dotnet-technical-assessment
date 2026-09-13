namespace Domains.Entities
{
    public class ProductImage
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required Product Product { get; set; }
    }
}
