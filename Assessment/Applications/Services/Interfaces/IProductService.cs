using Domains.Entities;

namespace Applications.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
    }
}
