using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Helpers;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces.Basic;
using Tch.RestClient.Services.Extensions;

namespace Tch.RestClient.Services.Basic
{
   /// <summary>
   ///    This class is implementation of <see cref="IHttpPayloadService{TRequest}" /> for 'single' mime-type http requests
   /// </summary>
   internal class HttpPayloadService4SingleContentPayload : HttpPayloadServiceBase<SingleContentPayload>
   {
      private readonly IHttpService _httpMessageService;

      #region ctor

      public HttpPayloadService4SingleContentPayload() : this(new HttpMessageService())
      {
      }

      internal HttpPayloadService4SingleContentPayload(IHttpService httpMessageService)
      {
         _httpMessageService = httpMessageService;
      }

      #endregion

      protected override Task<HttpResponseMessage> SendImpl(HttpMethod httpMethod, string url, SingleContentPayload request, RestClientOptions restClientOptions)
      {
         var httpRequestMessage = new HttpRequestMessage(httpMethod, url);

         if (request.HttpContent != null)
         {
            httpRequestMessage.Content = request.HttpContent;
         }

         httpRequestMessage.AddHttpHeaders(request.HttpHeaders);
         return _httpMessageService.Send(httpRequestMessage, restClientOptions);
      }
   }
}