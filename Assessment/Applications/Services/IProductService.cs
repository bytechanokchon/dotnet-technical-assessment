using Domains.Entities;

namespace Applications.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
    }
}
