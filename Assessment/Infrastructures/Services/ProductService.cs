using Applications;
using Applications.Services;
using Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Services
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
