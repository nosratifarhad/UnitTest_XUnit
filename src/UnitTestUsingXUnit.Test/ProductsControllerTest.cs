using System.Net.Mime;
using System.Text.Json;
using System.Text;
using UnitTestUsingXUnit.Test.MockDatas;
using System.Net;
using FluentAssertions;

namespace UnitTestUsingXUnit.Test
{
    public class ProductsControllerTest : IClassFixture<StartupFactory>
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
        public async Task When_ValidCreateProductInCreateProductAsyncthene_ShouldBeCreated()
        {
            var createProduct = ProductMockData.ValidCreateProduct;

            string uri = $"/api/v1/product";

            var bodyStr = JsonSerializer.Serialize(createProduct);
            var result = new StringContent(bodyStr, Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _httpClient.PostAsync(uri, result);

            response.IsSuccessStatusCode.Should().BeTrue();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }


        [Fact]
        public async Task When_InValidCreateProductInCreateProductAsyncthene_ShouldBeCreated()
        {
            var createProduct = ProductMockData.InValidCreateProduct;

            string uri = $"/api/v1/product";

            var bodyStr = JsonSerializer.Serialize(createProduct);
            var result = new StringContent(bodyStr, Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _httpClient.PostAsync(uri, result);

            response.IsSuccessStatusCode.Should().BeFalse();
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);

        }
    }

}