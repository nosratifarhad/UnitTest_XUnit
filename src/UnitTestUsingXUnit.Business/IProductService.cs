using UnitTestUsingXUnit.Business.Dtos;

namespace UnitTestUsingXUnit.Business
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();

        Task CreateProductAsync(CreateProduct createProduct);

    }
}
