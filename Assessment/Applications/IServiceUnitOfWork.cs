using Applications.Services;

namespace Applications
{
    public interface IServiceUnitOfWork
    {
        public IProductService ProductService { get; }
        public IJwtGenerator JwtGenerator { get; }
        public IExternalBookService ExternalBookService { get; set; }
    }
}
