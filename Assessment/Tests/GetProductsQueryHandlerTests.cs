using Applications;
using Applications.DTOs.Products;
using Applications.Handlers.Products.Queries;
using Applications.Services;
using Domains.Entities;
using Moq;
using Xunit;

namespace Tests.Handlers.Products
{
    public class GetProductsQueryHandlerTests
    {
        private readonly Mock<IServiceUnitOfWork> _serviceUnitOfWorkMock;
        private readonly Mock<IProductService> _productServiceMock;

        private readonly GetProductsQuery.GetProductsQueryHandler _handler;

        public GetProductsQueryHandlerTests()
        {
            _serviceUnitOfWorkMock = new Mock<IServiceUnitOfWork>();
            _productServiceMock = new Mock<IProductService>();

            _serviceUnitOfWorkMock
                .Setup(x => x.ProductService)
                .Returns(_productServiceMock.Object);

            _handler = new GetProductsQuery.GetProductsQueryHandler(
                _serviceUnitOfWorkMock.Object
            );
        }

        [Fact]
        public async Task Handle_ShouldReturnProductDtos_WhenProductsExist()
        {
            // Arrange

            var createdAt = new DateTime(2026, 9, 13, 10, 0, 0);
            var updatedAt = new DateTime(2026, 9, 13, 11, 0, 0);

            var products = new List<Product>
            {
                new Product
                {
                    Id = "product-001",
                    Name = "iPhone 17",
                    Description = "Apple smartphone",
                    Price = 39900m,

                    CreatedAt = createdAt,
                    CreatedBy = "admin",

                    UpdatedAt = updatedAt,
                    UpdatedBy = "admin",

                    ProductImages = new List<ProductImage>
                    {
                        new ProductImage
                        {
                            Id = "image-001",
                            Name = "iphone-front.jpg"
                        },
                        new ProductImage
                        {
                            Id = "image-002",
                            Name = "iphone-back.jpg"
                        }
                    }
                }
            };

            _productServiceMock
                .Setup(x => x.GetProducts())
                .ReturnsAsync(products);

            var query = new GetProductsQuery();

            // Act

            var result = await _handler.Handle(
                query,
                CancellationToken.None
            );

            // Assert

            Assert.NotNull(result);

            Assert.Single(result);

            var product = result.First();

            Assert.Equal("product-001", product.ProductId);
            Assert.Equal("iPhone 17", product.ProductName);
            Assert.Equal("Apple smartphone", product.ProductDescription);
            Assert.Equal(39900m, product.Price);

            Assert.Equal(createdAt, product.CreatedAt);
            Assert.Equal("admin", product.CreatedBy);

            Assert.Equal(updatedAt, product.UpdatedAt);
            Assert.Equal("admin", product.UpdatedBy);

            Assert.NotNull(product.Images);
            Assert.Equal(2, product.Images.Count);

            Assert.Equal("image-001", product.Images[0].ProductImageId);
            Assert.Equal(
                "iphone-front.jpg",
                product.Images[0].ProductImageName
            );

            Assert.Equal("image-002", product.Images[1].ProductImageId);
            Assert.Equal(
                "iphone-back.jpg",
                product.Images[1].ProductImageName
            );

            _productServiceMock.Verify(
                x => x.GetProducts(),
                Times.Once
            );
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyList_WhenNoProductsExist()
        {
            // Arrange

            var products = new List<Product>();

            _productServiceMock
                .Setup(x => x.GetProducts())
                .ReturnsAsync(products);

            var query = new GetProductsQuery();

            // Act

            var result = await _handler.Handle(
                query,
                CancellationToken.None
            );

            // Assert

            Assert.NotNull(result);
            Assert.Empty(result);

            _productServiceMock.Verify(
                x => x.GetProducts(),
                Times.Once
            );
        }
    }
}