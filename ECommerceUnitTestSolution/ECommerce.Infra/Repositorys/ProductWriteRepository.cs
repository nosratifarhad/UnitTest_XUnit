using ECommerce.Domain.Products;
using ECommerce.Domain.Products.Entitys;

namespace ECommerce.Infra.Repositorys
{
    public class ProductWriteRepository : IProductWriteRepository
    {
        public Task<int> CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
