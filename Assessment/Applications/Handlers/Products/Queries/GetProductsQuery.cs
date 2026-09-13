using Applications.DTOs.Products;
using Applications.Services;
using MediatR;

namespace Applications.Handlers.Products.Queries
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
        public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
        {
            private readonly IServiceUnitOfWork _serviceUnitOfWork;

            public GetProductsQueryHandler(IServiceUnitOfWork serviceUnitOfWork)
            {
                this._serviceUnitOfWork = serviceUnitOfWork;
            }

            public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await this._serviceUnitOfWork.ProductService.GetProducts();

                List<ProductDto> productDtos = new List<ProductDto>();
                foreach (var product in products)
                {
                    ProductDto productDto = new ProductDto()
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        Price = product.Price,
                        CreatedAt = product.CreatedAt,
                        CreatedBy = product.CreatedBy,
                        UpdatedAt = product.UpdatedAt,
                        UpdatedBy = product.UpdatedBy,
                    };

                    if (product.ProductImages != null)
                    {
                        List<ProductImageDto> productImageDtos = product.ProductImages
                        .Select(productImage => new ProductImageDto()
                        {
                            ProductImageId = productImage.Id,
                            ProductImageName = productImage.Name,
                        })
                        .ToList();

                        productDto.Images = productImageDtos;
                    }

                    productDtos.Add(productDto);
                }

                return productDtos;
            }
        }
    }
}
