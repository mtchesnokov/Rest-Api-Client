using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Helpers;
using Tch.HttpClient.Domain.Objects;
using Tch.HttpClient.Interfaces.Helpers1;

namespace Tch.HttpClient.Services.Helpers1
{
   /// <summary>
   ///    This class is implementation of <see cref="IHttpService{TRequest}" /> for 'multiple' mime-type http requests
   /// </summary>
   internal class HttpService4MultiContentRequests : HttpServiceBase<MultiContentHttpRequest>
   {
      private readonly IHttpMessageService _httpMessageService;

      #region ctor

      public HttpService4MultiContentRequests(IHttpMessageService httpMessageService)
      {
         _httpMessageService = httpMessageService;
      }

      #endregion

      protected override async Task<HttpResponseMessage> SendImpl(HttpMethod httpMethod, string url, MultiContentHttpRequest request, HttpClientOptions httpClientOptions)
      {
         var multipartContent = new MultipartFormDataContent();

         foreach (var httpContent in request.HttpContents)
         {
            multipartContent.Add(httpContent);
         }

         var httpRequestMessage = new HttpRequestMessage(httpMethod, url);
         httpRequestMessage.Content = multipartContent;
         httpRequestMessage.AddHttpHeaders(request.HttpHeaders);
         var httpResponseMessage = await _httpMessageService.Send(httpRequestMessage, httpClientOptions);
         return httpResponseMessage;
      }
   }
}