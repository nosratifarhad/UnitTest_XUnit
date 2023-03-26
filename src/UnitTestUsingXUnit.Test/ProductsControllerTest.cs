using System.Net.Mime;
using System.Text.Json;
using System.Text;
using UnitTestUsingXUnit.Test.MockDatas;
using System.Net;
using FluentAssertions;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestUsingXUnit.Test
{
    public class ProductsControllerTest : IClassFixture<IntegrationTestsFixture>
    {
        private readonly IntegrationTestsFixture fixture;

        public ProductsControllerTest(IntegrationTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task When_ValidCreateProductInCreateProductAsyncthene_MustBeCreated()
        {
            var createProduct = ProductMockData.ValidCreateProduct;

            string uri = $"/api/v1/product";
            
            var httpContent = CreateHttpContent(createProduct);
            var _httpClient = fixture.CreateClient();
            var response = await _httpClient.PostAsync(uri, httpContent);

            response.IsSuccessStatusCode.Should().BeTrue();
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // your must segregate to helper or common class for use global test project
            HttpContent CreateHttpContent<T>(T model)
            {
                var bodyStr = JsonSerializer.Serialize(model);

                var result = new StringContent(bodyStr, Encoding.UTF8, MediaTypeNames.Application.Json);

                return result;
            }
        }


        [Fact]
        public async void When_InValidCreateProductInCreateProductAsyncthene_MustBeThrowExceptionMessageProductNameIsExist()
        {
            // Arrange
            var createProduct = ProductMockData.InValidCreateProduct;

            string uri = $"/api/v1/product";

            var httpContent = CreateHttpContent(createProduct);
           var _httpClient= fixture.CreateClient();
            // Act
            var response = await _httpClient.PostAsync(uri, httpContent).ConfigureAwait(false);

            // Assert
            response.IsSuccessStatusCode.Should().BeFalse();
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            
            var problem = await response.Content.ReadFromJsonAsync<object>().ConfigureAwait(false);

            //you can get exception message and compare here.
            ///exceptionMessage == "Product Name Is Exist";

            // your must segregate to helper or common class for use global test project
            HttpContent CreateHttpContent<T>(T model)
            {
                var bodyStr = JsonSerializer.Serialize(model);

                var result = new StringContent(bodyStr, Encoding.UTF8, MediaTypeNames.Application.Json);

                return result;
            }
        }



    }

}