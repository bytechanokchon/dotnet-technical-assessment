using Applications.Services.Interfaces;

namespace Applications.Services
{
    public interface IServiceUnitOfWork
    {
        public IProductService ProductService { get; }
    }
}
