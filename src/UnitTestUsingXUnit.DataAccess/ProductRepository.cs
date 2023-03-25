using UnitTestUsingXUnit.DataAccess.Dtos;
using UnitTestUsingXUnit.DataAccess.Enum;
using UnitTestUsingXUnit.DataAccess.MockData;

namespace UnitTestUsingXUnit.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        public async Task<int> CreateProductAsync(CreateProduct createProduct)
        {
            return await Task.FromResult(ProductMockData.ProductId);
        }

        public async Task<ProductDto> GetProductAsync(int productId)
        {
            return await Task.FromResult(ProductMockData.ProductDto);
        }

        public async Task<ProductDto> GetProductAsync(string productName)
        {
            return await Task.FromResult(ProductMockData.ProductDto);
        }

        public Task<bool> GetExistProductTypeAsync(ProductType productType)
        {
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            return await Task.FromResult(ProductMockData.ProductDtoList);
        }

        public Task<bool> GetExistProductCategorysAsync(string productCategorys)
        {
            throw new NotImplementedException();
        }
    }
}