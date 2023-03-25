using UnitTestUsingXUnit.DataAccess.Enum;

namespace UnitTestUsingXUnit.DataAccess.Dtos
{
    public class CreateProduct
    {
        public string ProductName { get; set; }

        public string ProductTitle { get; set; }

        public ProductType ProductType { get; set; }

        public List<ProductCategory> ProductCategorys { get; set; }

        public float ProductPrice { get; set; }
    }
}
