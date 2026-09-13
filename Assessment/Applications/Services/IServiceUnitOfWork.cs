namespace Applications.Services
{
    public interface IServiceUnitOfWork
    {
        public IProductService ProductService { get; }
    }
}
