using ECommerce.Domain.Products;
using ECommerce.Domain.Products.Dtos.ProductDtos;
using ECommerce.Domain.Products.Entitys;
using ECommerce.Service.Contract;
using ECommerce.Service.InputModels.ProductInputModels;
using ECommerce.Service.ViewModels.ProductViewModels;
using System.Net.Http.Headers;

namespace ECommerce.Service.Services
{
    public class ProductService : IProductService
    {
        #region Fields
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        #endregion Fields

        #region Ctor

        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        #endregion Ctor
        public async Task<ProductViewModel> GetProduct(int productId)
        {
            var productDto = await _productReadRepository.GetProduct(productId).ConfigureAwait(false);

            var productViewModel = CreateProductViewModelFromProductDto(productDto);

            return productViewModel;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var productDtos = await _productReadRepository.GetProducts().ConfigureAwait(false);

            var productViewModels = CreateProductViewModelsFromProductDtos(productDtos);

            return productViewModels;
        }

        public async Task<int> CreateProductAsync(CreateProductInputModel inputModel)
        {
            var productEntoty = CreateProductEntityFromInputModel(inputModel);

            return await _productWriteRepository.CreateProductAsync(productEntoty).ConfigureAwait(false);
        }

        public async Task UpdateProductAsync(UpdateProductInputModel inputModel)
        {
            var productEntoty = CreateProductEntityFromInputModel(inputModel);

            await _productWriteRepository.UpdateProductAsync(productEntoty).ConfigureAwait(false);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _productWriteRepository.DeleteProductAsync(productId).ConfigureAwait(false);
        }


        #region Private

        private Product CreateProductEntityFromInputModel(CreateProductInputModel inputModel)
            => new Product(inputModel.ProductName, inputModel.ProductTitle, inputModel.ProductDescription, inputModel.ProductCategory, inputModel.MainImageName, inputModel.MainImageTitle, inputModel.MainImageUri, inputModel.Color, inputModel.IsExisting, inputModel.IsFreeDelivery, inputModel.Materials, inputModel.Weight);

        private Product CreateProductEntityFromInputModel(UpdateProductInputModel inputModel)
            => new Product(inputModel.ProductId, inputModel.ProductName, inputModel.ProductTitle, inputModel.ProductDescription, inputModel.ProductCategory, inputModel.MainImageName, inputModel.MainImageTitle, inputModel.MainImageUri, inputModel.Color, inputModel.IsExisting, inputModel.IsFreeDelivery, inputModel.Materials, inputModel.Weight);

        private ProductViewModel CreateProductViewModelFromProductDto(ProductDto dto)
            => new ProductViewModel()
            {
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                ProductTitle = dto.ProductTitle,
                ProductDescription = dto.ProductDescription,
                ProductCategory = dto.ProductCategory,
                MainImageName = dto.MainImageName,
                MainImageTitle = dto.MainImageTitle,
                MainImageUri = dto.MainImageUri,
                Color = dto.Color,
                IsExisting = dto.IsExisting,
                IsFreeDelivery = dto.IsFreeDelivery,
                Materials = dto.Materials,
                Weight = dto.Weight
            };

        private IEnumerable<ProductViewModel> CreateProductViewModelsFromProductDtos(IEnumerable<ProductDto> dtos)
        {
            ICollection<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (var ProductDto in dtos)
                productViewModels.Add(
                     new ProductViewModel()
                     {

                         ProductId = ProductDto.ProductId,
                         ProductName = ProductDto.ProductName,
                         ProductTitle = ProductDto.ProductTitle,
                         ProductDescription = ProductDto.ProductDescription,
                         ProductCategory = ProductDto.ProductCategory,
                         MainImageName = ProductDto.MainImageName,
                         MainImageTitle = ProductDto.MainImageTitle,
                         MainImageUri = ProductDto.MainImageUri,
                         Color = ProductDto.Color,
                         IsExisting = ProductDto.IsExisting,
                         IsFreeDelivery = ProductDto.IsFreeDelivery,
                         Materials = ProductDto.Materials,
                         Weight = ProductDto.Weight
                     });


            return (IEnumerable<ProductViewModel>)productViewModels;
        }

        #endregion Private
    }
}
