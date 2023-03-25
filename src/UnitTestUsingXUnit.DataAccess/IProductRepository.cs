using UnitTestUsingXUnit.DataAccess.Dtos;

namespace UnitTestUsingXUnit.DataAccess
{
    public interface IProductRepository
    {
        Task<ProductDto> GetProductAsync(int productId);

        Task<IEnumerable<ProductDto>> GetProductsAsync();

        Task<int> CreateProductAsync(CreateProduct createProduct);
    }
}
