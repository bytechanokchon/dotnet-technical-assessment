using Applications;
using Applications.Services;
using Infrastructures.Services;
using Microsoft.Extensions.Configuration;

namespace Infrastructures
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        public ServiceUnitOfWork(IApplicationDbContext context, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.JwtGenerator = new JwtGenerator(configuration);

            this.ProductService = new ProductService(context);

            this.ExternalBookService = new ExternalBookService(httpClientFactory);
        }

        public IJwtGenerator JwtGenerator { get; private set; }
        public IProductService ProductService { get; private set; }
        public IExternalBookService ExternalBookService { get; set; }
    }
}
