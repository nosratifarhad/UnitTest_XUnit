using UnitTestUsingXUnit.DataAccess.Dtos;
using UnitTestUsingXUnit.DataAccess.Enum;
using UnitTestUsingXUnit.DataAccess.MockData;

namespace UnitTestUsingXUnit.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        public async Task<int> CreateProductAsync(CreateProduct createProduct)
        {
            return await Task.FromResult(ProductDataAccessMockData.ProductId);
        }

        public async Task<ProductDto> GetProductAsync(int productId)
        {
            return await Task.FromResult(ProductDataAccessMockData.ProductDto);
        }

        public async Task<ProductDto> GetProductAsync(string productName)
        {
            return await Task.FromResult(ProductDataAccessMockData.ProductDto);
        }

        public Task<bool> GetExistProductTypeAsync(ProductType productType)
        {
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            return await Task.FromResult(ProductDataAccessMockData.ProductDtoList);
        }

        public Task<bool> GetExistProductCategorysAsync(string productCategorys)
        {
            return Task.FromResult(true);
        }
    }
}