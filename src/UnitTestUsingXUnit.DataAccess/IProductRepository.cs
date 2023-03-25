using UnitTestUsingXUnit.DataAccess.Dtos;
using UnitTestUsingXUnit.DataAccess.Enum;

namespace UnitTestUsingXUnit.DataAccess
{
    public interface IProductRepository
    {
        Task<ProductDto> GetProductAsync(int productId);

        Task<bool> GetExistProductTypeAsync(ProductType productType);

        Task<bool> GetExistProductCategorysAsync(string productCategorys);

        Task<ProductDto> GetProductAsync(string productName);

        Task<IEnumerable<ProductDto>> GetProductsAsync();

        Task<int> CreateProductAsync(CreateProduct createProduct);
    }
}
