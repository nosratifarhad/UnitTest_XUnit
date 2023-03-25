using UnitTestUsingXUnit.DataAccess.Dtos;

namespace UnitTestUsingXUnit.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        public Task<int> CreateProductAsync(CreateProduct createProduct)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}