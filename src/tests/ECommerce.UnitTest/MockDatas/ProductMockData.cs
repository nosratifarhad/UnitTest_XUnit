using Bogus;
using ECommerce.Domain.Products.Enums;
using ECommerce.Service.InputModels.ProductInputModels;

namespace ECommerce.UnitTest.MockDatas
{
    public static class ProductMockData
    {
        public static CreateProductInputModel ProductNameIsNullInC1reateProductInputModel()
            => new Faker<CreateProductInputModel>()
              .RuleFor(bp => bp.ProductName, f => null)
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

        public static CreateProductInputModel ProductTitleIsNullInCreateProductInputModel()
            => new Faker<CreateProductInputModel>()
              .RuleFor(bp => bp.ProductName, f => f.Name.FirstName())
              .RuleFor(bp => bp.ProductTitle, f => null)
              .RuleFor(bp => bp.ProductDescription, f => f.Name.JobDescriptor())
              .RuleFor(bp => bp.ProductCategory, f => f.Random.Enum<ProductCategory>())
              .RuleFor(bp => bp.MainImageName, f => f.Name.FullName())
              .RuleFor(bp => bp.MainImageTitle, f => f.Name.FullName())
              .RuleFor(bp => bp.MainImageUri, f => f.Name.FullName())
              .RuleFor(bp => bp.Color, f => f.Random.Enum<ProductColor>())
              .RuleFor(bp => bp.IsFreeDelivery, f => f.Random.Bool())
              .RuleFor(bp => bp.IsExisting, f => f.Random.Bool())
              .RuleFor(bp => bp.Weight, f => f.Random.Number());

        public static CreateProductInputModel ValidCreateProductInputModel()
            => new Faker<CreateProductInputModel>()
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
    }
}
