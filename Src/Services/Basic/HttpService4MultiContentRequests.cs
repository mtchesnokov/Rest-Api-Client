using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Helpers;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces.Basic;
using Tch.RestClient.Services.Extensions;

namespace Tch.RestClient.Services.Basic
{
   /// <summary>
   ///    This class is implementation of <see cref="IHttpService{TRequest}" /> for 'multiple' mime-type http requests
   /// </summary>
   internal class HttpService4MultiContentRequests : HttpServiceBase<MultiContentHttpRequest>
   {
      private readonly IHttpMessageService _httpMessageService;

      #region ctor

      public HttpService4MultiContentRequests() : this(new HttpMessageService())
      {
      }

      internal HttpService4MultiContentRequests(IHttpMessageService httpMessageService)
      {
         _httpMessageService = httpMessageService;
      }

      #endregion

      protected override Task<HttpResponseMessage> SendImpl(HttpMethod httpMethod, string url, MultiContentHttpRequest request, HttpClientOptions httpClientOptions)
      {
         var multipartContent = new MultipartFormDataContent();

         foreach (var httpContent in request.HttpContents)
         {
            multipartContent.Add(httpContent);
         }

         var httpRequestMessage = new HttpRequestMessage(httpMethod, url);
         httpRequestMessage.Content = multipartContent;
         httpRequestMessage.AddHttpHeaders(request.HttpHeaders);
         return _httpMessageService.Send(httpRequestMessage, httpClientOptions);
      }
   }
}