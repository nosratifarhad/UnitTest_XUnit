using Bogus;
using UnitTestUsingXUnit.DataAccess.Dtos;
using UnitTestUsingXUnit.DataAccess.Enum;

namespace UnitTestUsingXUnit.Test.MockDatas
{
    public static class ProductMockData
    {
        public static CreateProduct DynamicCreateProduct
        {
            get
            {
                return new Faker<CreateProduct>()
                        .RuleFor(bp => bp.ProductName, f => f.Name.FullName())
                        .RuleFor(bp => bp.ProductTitle, f => f.Name.JobTitle())
                        .RuleFor(bp => bp.ProductType, f => ProductType.None)
                        .RuleFor(bp => bp.ProductCategorys,
                            f => Enumerable.Range(1, 7)
                            .Select(_ => ProductCategory.None).ToList())
                        .RuleFor(bp => bp.ProductPrice, f => f.Random.Float());
            }
        }

    }
}
