using Bogus;
using ECommerce.Domain.Products;
using ECommerce.Domain.Products.Dtos.ProductDtos;
using ECommerce.Domain.Products.Entitys;
using ECommerce.Domain.Products.Enums;
using System.Data;

namespace ECommerce.Infra.Repositorys
{
    public class ProductReadRepository : IProductReadRepository
    {
        public Task<ProductDto> GetProduct(int productId)
        {
            if (productId <= 5)
                return Task.FromResult(CreateFakerProductDto());

            return Task.FromResult(new ProductDto());
        }

        public Task<IEnumerable<ProductDto>> GetProducts()
        {
            return Task.FromResult((IEnumerable<ProductDto>)CreateFakerProductDtos());
        }

        public Task<bool> IsExistProduct(int productId)
        {
            if (productId <= 5)
                return Task.FromResult(true);

            return Task.FromResult(false);
        }


        public static ProductDto CreateFakerProductDto()
           => new Faker<ProductDto>()
              .RuleFor(bp => bp.ProductId, f => f.Random.Number())
              .RuleFor(bp => bp.ProductName, f => f.Name.FirstName())
              .RuleFor(bp => bp.ProductTitle, f => f.Name.JobTitle())
              .RuleFor(bp => bp.ProductDescription, f => f.Name.JobDescriptor())
              .RuleFor(bp => bp.ProductCategory, f => f.Random.Enum<ProductCategory>())
              .RuleFor(bp => bp.MainImageName, f => f.Name.FullName())
              .RuleFor(bp => bp.MainImageTitle, f => f.Name.FullName())
              .RuleFor(bp => bp.MainImageUri, f => f.Name.FullName())
              .RuleFor(bp => bp.Color, f => f.Random.Enum<ProductColor>())
              .RuleFor(bp => bp.IsFreeDelivery, f => f.Random.Bool())
              .RuleFor(bp => bp.IsExisting, f => f.Random.Bool())
              .RuleFor(bp => bp.Weight, f => f.Random.Number());

        public static List<ProductDto> CreateFakerProductDtos()
           => new Faker<ProductDto>()
              .RuleFor(bp => bp.ProductId, f => f.Random.Number())
              .RuleFor(bp => bp.ProductName, f => f.Name.FirstName())
              .RuleFor(bp => bp.ProductTitle, f => f.Name.JobTitle())
              .RuleFor(bp => bp.ProductDescription, f => f.Name.JobDescriptor())
              .RuleFor(bp => bp.ProductCategory, f => f.Random.Enum<ProductCategory>())
              .RuleFor(bp => bp.MainImageName, f => f.Name.FullName())
              .RuleFor(bp => bp.MainImageTitle, f => f.Name.FullName())
              .RuleFor(bp => bp.MainImageUri, f => f.Name.FullName())
              .RuleFor(bp => bp.Color, f => f.Random.Enum<ProductColor>())
              .RuleFor(bp => bp.IsFreeDelivery, f => f.Random.Bool())
              .RuleFor(bp => bp.IsExisting, f => f.Random.Bool())
              .RuleFor(bp => bp.Weight, f => f.Random.Number()).Generate(5);


    }
}
