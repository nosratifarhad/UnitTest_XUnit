using UnitTestUsingXUnit.DataAccess.Dtos;

namespace UnitTestUsingXUnit.DataAccess.MockData
{
    public static class ProductMockData
    {
        public static int ProductId { get { return 100; } }

        public static ProductDto ProductDto { get; set; }

        public static List<ProductDto> ProductDtoList
            => new List<ProductDto>()
            {
                new ProductDto()
                {},
                new ProductDto()
                {}
            };
    }
}
