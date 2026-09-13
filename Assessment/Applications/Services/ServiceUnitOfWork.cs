using Applications.Services.Implements;
using Applications.Services.Interfaces;

namespace Applications.Services
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
