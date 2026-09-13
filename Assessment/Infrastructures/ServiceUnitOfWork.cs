using Applications;
using Applications.Services;
using Infrastructures.Services;
using Microsoft.Extensions.Configuration;

namespace Infrastructures
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        public ServiceUnitOfWork(IApplicationDbContext context, IConfiguration configuration)
        {
            this.JwtGenerator = new JwtGenerator(configuration);

            this.ProductService = new ProductService(context);
        }

        public IJwtGenerator JwtGenerator { get; private set; }

        public IProductService ProductService { get; private set; }
    }
}
