using ECommerce.Domain.Products;
using ECommerce.Service.Services;
using Moq;
using FluentAssertions;
using ECommerce.Domain.Products.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UnitTest.TestServices
{
    public class ProductServiceUnitTest
    {

        #region GetProduct

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void When_ValidProductIdInGetProduct_Then_ReturnedproductViewModel(int productId)
        {
            var MoqProductReadRepository = new Mock<IProductReadRepository>();
            var MoqProductWriteRepository = new Mock<IProductWriteRepository>();

            MoqProductReadRepository.Setup(p => p.GetProduct(It.IsAny<int>()))
                .ReturnsAsync(new ProductDto() 
                { ProductId = productId, 
                    ProductName = "test", 
                    ProductTitle = "tst" 
                });

            var ProductService = new ProductService(MoqProductReadRepository.Object, MoqProductWriteRepository.Object);

            var productViewModel = await ProductService.GetProductAsync(productId).ConfigureAwait(false);

            productViewModel.ProductId.Should().Be(productId);
            productViewModel.ProductName.Should().NotBeNull();
            productViewModel.ProductTitle.Should().NotBeNull();
            productViewModel.Should().NotBeNull();
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public async void When_InValidProductIdInGetProduct_Then_ReturnedproductViewModel(int productId)
        {
            var MoqProductReadRepository = new Mock<IProductReadRepository>();
            var MoqProductWriteRepository = new Mock<IProductWriteRepository>();

            MoqProductReadRepository.Setup(p => p.GetProduct(It.IsAny<int>()))
                .ReturnsAsync(new ProductDto());

            var ProductService = new ProductService(MoqProductReadRepository.Object, MoqProductWriteRepository.Object);

            var productViewModel = await ProductService.GetProductAsync(productId).ConfigureAwait(false);

            productViewModel.ProductId.Should().Be(0);
            productViewModel.ProductName.Should().BeNull();
            productViewModel.ProductTitle.Should().BeNull();
            productViewModel.Should().NotBeNull();
        }

        [Theory]
        [InlineData(0)]
        public async void When_ZeroProductIdInGetProduct_Then_ThrowArgumentExceptionBeMessageProductIdIsInvalid(int productId)
        {
            var MoqProductReadRepository = new Mock<IProductReadRepository>();
            var MoqProductWriteRepository = new Mock<IProductWriteRepository>();

            var ProductService = new ProductService(MoqProductReadRepository.Object, MoqProductWriteRepository.Object);

            var exception = await Assert.ThrowsAsync<ArgumentException>(
            async () =>
            {
                await ProductService.GetProductAsync(productId).ConfigureAwait(false);
            });
            
            exception.Message.Should().Be("Product Id Is Invalid");
        }

        #endregion GetProduct
    }
}