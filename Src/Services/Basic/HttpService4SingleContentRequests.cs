using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Helpers;
using Tch.HttpClient.Domain.Objects;
using Tch.HttpClient.Interfaces.Basic;
using Tch.HttpClient.Services.Helpers1;

namespace Tch.HttpClient.Services.Basic
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

      protected override async Task<HttpResponseMessage> SendImpl(HttpMethod httpMethod, string url, SingleContentHttpRequest request, HttpClientOptions httpClientOptions)
      {
         var httpRequestMessage = new HttpRequestMessage(httpMethod, url);

         if (request.HttpContent != null)
         {
            httpRequestMessage.Content = request.HttpContent;
         }

         httpRequestMessage.AddHttpHeaders(request.HttpHeaders);
         var httpResponseMessage = await _httpMessageService.Send(httpRequestMessage, httpClientOptions);
         return httpResponseMessage;
      }
   }
}