using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using System.Text;
using System;
using UnitTestUsingXUnit.Test.MockDatas;
using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Net.Mail;

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

            string exceptionMessage = response.ReasonPhrase;

            //exceptionMessage.Should().Be("Product Name Is Exist");

            var erere = await response.Content.ReadFromJsonAsync<Exception>();


        }

    }
    //    private HttpResponseMessage CreateResponse(HttpRequestMessage request, Exception ex)
    //    {
    //        string message = ex.Message;

    //        HttpStatusCode code = 0;

    //        if (ex is KeyNotFoundException) code = HttpStatusCode.NotFound;
    //        else if (ex is ArgumentException) code = HttpStatusCode.BadRequest;
    //        else if (ex is InvalidOperationException) code = HttpStatusCode.BadRequest;
    //        else if (ex is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized;
    //        else if (ex is HttpException)
    //        {
    //            // HttpExceptions are thrown when request between IdentityServer and the API server have failed.
    //            // IdentityServer has generated an error, the API server received it and now it needs to relay it back to the client.
    //            var httpException = (HttpException)ex;

    //            code = (HttpStatusCode)httpException.GetHttpCode();
    //            message = httpException.Message;
    //        }
    //        else
    //        {
    //            code = HttpStatusCode.InternalServerError;

    //            // For security reasons, when an exception is not handled the system should return a general error, not exposing the real error information
    //            // In development time, the programmer will need the details of the error, so this general message is disabled.
    //#if DEBUG
    //            message = ex.Message;
    //#else
    //            message = Errors.InternalServerError;
    //#endif
    //        }

    //        // For some reason the request.CreateErrorResponse() method ignores the message given to it and parses its own message.
    //        // The error response is constructed manually.
    //        return CreateErrorResponse(request, code, message);
    //    }

    //    private HttpResponseMessage CreateErrorResponse(HttpRequestMessage request, HttpStatusCode code, string message)
    //    {
    //        var content = new { Message = message };

    //        return new HttpResponseMessage(code)
    //        {
    //            ReasonPhrase = message,
    //            RequestMessage = request,
    //            Content = new ObjectContent(content.GetType(), content, new JsonMediaTypeFormatter())
    //        };
    //    }

}