using ECommerce.Domain.Products;
using ECommerce.Service.Services;
using Moq;
using FluentAssertions;

namespace ECommerce.UnitTest.TestServices
{
    public class UnitTestProductService
    {

        #region GetProduct

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public async void When_InValidProductIdInGetProduct_ThenReturnedproductViewModel(int productId)
        {
            var MoqProductReadRepository = new Mock<IProductReadRepository>();
            var MoqProductWriteRepository = new Mock<IProductWriteRepository>();

            var ProductService = new ProductService(MoqProductReadRepository.Object, MoqProductWriteRepository.Object);

            var productViewModel = await ProductService.GetProductAsync(productId).ConfigureAwait(false);

            productViewModel.ProductId.Should().Be(0);
            productViewModel.ProductName.Should().BeNull();
            productViewModel.ProductTitle.Should().BeNull();
            productViewModel.Should().NotBeNull();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void When_ValidProductIdInGetProduct_ThenReturnedproductViewModel(int productId)
        {
            var MoqProductReadRepository = new Mock<IProductReadRepository>();
            var MoqProductWriteRepository = new Mock<IProductWriteRepository>();

            var ProductService = new ProductService(MoqProductReadRepository.Object, MoqProductWriteRepository.Object);

            var productViewModel = await ProductService.GetProductAsync(productId).ConfigureAwait(false);

            productViewModel.ProductId.Should().Be(productId);
            productViewModel.ProductName.Should().NotBeNull();
            productViewModel.ProductTitle.Should().NotBeNull();
            productViewModel.Should().NotBeNull();

        }

        #endregion GetProduct
    }
}