using Applications.Services.Interfaces;
using Domains.Entities;
using Microsoft.EntityFrameworkCore;
namespace Applications.Services.Implements
{
    public class ProductService : IProductService

    {
        private readonly IApplicationDbContext _context;

        public ProductService(IApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await this._context.Products
                .Include(product => product.ProductImages)
                .ToListAsync();
        }
    }
}
