using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using System.Text;
using System;
using UnitTestUsingXUnit.Test.MockDatas;
using System.Net;

namespace UnitTestUsingXUnit.Test
{
    public class ProductsControllerTest: IClassFixture<StartupFactory>
    {
        #region Fields
        private readonly HttpClient _httpClient;
        private string _accessToken = string.Empty;
        #endregion Fields

        #region Ctor
        public ProductsControllerTest(StartupFactory startupFactory)
        {
            _httpClient = startupFactory.CreateClient();
        }
        #endregion Ctor

        [Fact]
        public async Task When_ValidCreateProductInCreateProductAsyncthene_CreatedInDataBase()
        {
            var createProduct = ProductMockData.DynamicCreateProduct;

            string uri = $"/api/v1/product";

            var bodyStr = JsonSerializer.Serialize(createProduct);
            var result = new StringContent(bodyStr, Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _httpClient.PostAsync(uri, result);

            response.EnsureSuccessStatusCode();

            //response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        }
    }
}