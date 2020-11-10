using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Helpers;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces.Basic;
using Tch.RestClient.Services.Extensions;

namespace Tch.RestClient.Services.Basic
{
   /// <summary>
   ///    This class is implementation of <see cref="IHttpService{TRequest}" /> for 'single' mime-type http requests
   /// </summary>
   internal class HttpService4SingleContentRequests : HttpServiceBase<SingleContentHttpRequest>
   {
      private readonly IHttpMessageService _httpMessageService;

      #region ctor

      public HttpService4SingleContentRequests() : this(new HttpMessageService())
      {
      }

      internal HttpService4SingleContentRequests(IHttpMessageService httpMessageService)
      {
         _httpMessageService = httpMessageService;
      }

      #endregion

      protected override Task<HttpResponseMessage> SendImpl(HttpMethod httpMethod, string url, SingleContentHttpRequest request, HttpClientOptions httpClientOptions)
      {
         var httpRequestMessage = new HttpRequestMessage(httpMethod, url);

         if (request.HttpContent != null)
         {
            httpRequestMessage.Content = request.HttpContent;
         }

         httpRequestMessage.AddHttpHeaders(request.HttpHeaders);
         return _httpMessageService.Send(httpRequestMessage, httpClientOptions);
      }
   }
}