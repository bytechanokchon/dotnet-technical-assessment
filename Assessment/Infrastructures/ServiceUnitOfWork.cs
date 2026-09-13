using Applications;
using Applications.Services;
using Infrastructures.Services;

namespace Infrastructures
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        public ServiceUnitOfWork(IApplicationDbContext context)
        {
            this.ProductService = new ProductService(context);
        }

        public IProductService ProductService { get; private set; }
    }
}
