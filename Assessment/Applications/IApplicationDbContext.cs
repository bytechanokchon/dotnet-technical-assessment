using Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace Applications
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; }
        public DbSet<ProductImage> ProductImages { get;}

        public Task<int> SaveChangeAsync(CancellationToken cancellationToken);
    }
}
