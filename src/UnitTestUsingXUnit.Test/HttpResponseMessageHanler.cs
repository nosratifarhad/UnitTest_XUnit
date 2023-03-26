//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Formatting;

//namespace UnitTestUsingXUnit.Test
//{
//    public class HttpResponseMessageHanler
//    {
//        public HttpResponseMessage CreateResponse(HttpRequestMessage request, Exception ex)
//        {
//            string message = ex.Message;

//            HttpStatusCode code = 0;

//            if (ex is KeyNotFoundException) code = HttpStatusCode.NotFound;
//            else if (ex is ArgumentException) code = HttpStatusCode.BadRequest;
//            else if (ex is InvalidOperationException) code = HttpStatusCode.BadRequest;
//            else if (ex is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized;
//            else if (ex is Exception)
//            {
//                // HttpExceptions are thrown when request between IdentityServer and the API server have failed.
//                // IdentityServer has generated an error, the API server received it and now it needs to relay it back to the client.
//                var httpException = (Exception)ex;

//                code = (HttpStatusCode)httpException.HResult;
//                message = httpException.Message;
//            }
//            else
//            {
//                code = HttpStatusCode.InternalServerError;

//                // For security reasons, when an exception is not handled the system should return a general error, not exposing the real error information
//                // In development time, the programmer will need the details of the error, so this general message is disabled.
//#if DEBUG
//                message = ex.Message;
//#else
//                    message = Errors.InternalServerError;
//#endif
//            }

//            // For some reason the request.CreateErrorResponse() method ignores the message given to it and parses its own message.
//            // The error response is constructed manually.
//            return CreateErrorResponse(request, code, message);
//        }

//        private HttpResponseMessage CreateErrorResponse(HttpRequestMessage request, HttpStatusCode code, string message)
//        {
//            var content = new { Message = message };

//            return new HttpResponseMessage(code)
//            {
//                ReasonPhrase = message,
//                RequestMessage = request,
//                Content = new ObjectContent(content.GetType(), content, new JsonMediaTypeFormatter())
//            };
//        }

//    }
//}
