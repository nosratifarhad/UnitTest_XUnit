using UnitTestUsingXUnit.DataAccess.Dtos;

namespace UnitTestUsingXUnit.DataAccess.MockData
{
    public static class ProductMockData
    {
        public static int ProductId { get { return 100; } }

        public static ProductDto ProductDto
        {
            get
            {
                return new ProductDto()
                {
                    Id = ProductId,
                    ProductName = "laptop",
                    ProductTitle = "laptop",
                    ProductPrice = 58746,
                    ProductType = "pc"
                };
            }
        }

        public static List<ProductDto> ProductDtoList
            => new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = ProductId,
                    ProductName = "laptop",
                    ProductTitle = "laptop",
                    ProductPrice = 524765,
                    ProductType = "pc"
                },
                new ProductDto()
                {
                    Id = ProductId +10,
                    ProductName = "laptop",
                    ProductTitle = "laptop",
                    ProductPrice = 1454,
                    ProductType = "pc"
                }
            };
    }
}
