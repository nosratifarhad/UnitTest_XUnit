using UnitTestUsingXUnit.DataAccess;
using UnitTestUsingXUnit.DataAccess.Dtos;
using UnitTestUsingXUnit.DataAccess.Enum;

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
            await GetProductAsync(createProduct).ConfigureAwait(false);

            await GetExistProductTypeAsync(createProduct.ProductType).ConfigureAwait(false);

            await GetExistProductCategorysAsync(createProduct.ProductCategorys).ConfigureAwait(false);

            return await _productRepository.CreateProductAsync(createProduct);
        }

        public async Task<ProductDto> GetProductAsync(int productId)
        {
            await GetExistProductAsync(productId);

            return await _productRepository.GetProductAsync(productId);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }


        #region Private Method 

        private async Task GetProductAsync(CreateProduct createProduct)
        {
            var productDto = await _productRepository.GetProductAsync(createProduct.ProductName).ConfigureAwait(false);
            if (productDto != null)
                throw new Exception("Product Name Is Exist");
        }

        private async Task GetExistProductTypeAsync(ProductType productType)
        {
            var existProductType = await _productRepository.GetExistProductTypeAsync(productType).ConfigureAwait(false);
            if (!existProductType)
                throw new Exception("Product Type Is In Exist");
        }

        private async Task GetExistProductCategorysAsync(List<ProductCategory> productCategorys)
        {
            string categorys = ConvertProductCategoryListToJson(productCategorys);

            var existProductCategory = await _productRepository.GetExistProductCategorysAsync(categorys).ConfigureAwait(false);
            if (!existProductCategory)
                throw new Exception("Product Category Is In Exist");
        }

        private async Task<ProductDto> GetExistProductAsync(int productId)
        {
            var productDto = await _productRepository.GetProductAsync(productId).ConfigureAwait(false);
            if (productDto != null)
                throw new Exception("Product Id Is Exist");

            return productDto;
        }


        private string ConvertProductCategoryListToJson(List<ProductCategory> productCategorys)
            => string.Join(",", productCategorys);


        #endregion
    }
}
