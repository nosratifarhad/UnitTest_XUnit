using UnitTestUsingXUnit.DataAccess;
using UnitTestUsingXUnit.DataAccess.Dtos;

namespace UnitTestUsingXUnit.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<int> CreateProductAsync(CreateProduct createProduct)
        {
           return await _productRepository.CreateProductAsync(createProduct);
        }

        public async Task<ProductDto> GetProductAsync(int productId)
        {
           return await _productRepository.GetProductAsync(productId);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}
