using UnitTestUsingXUnit.Business.Dtos;

namespace UnitTestUsingXUnit.Business
{
    public class ProductService : IProductService
    {
        public ProductService()
        {
            
        }

        public Task CreateProductAsync(CreateProduct createProduct)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
