using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Helpers;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces.Helpers;
using Tch.RestClient.Services.Extensions;

namespace Tch.RestClient.Services.Helpers
{
   /// <summary>
   ///    This class is implementation of <see cref="ISendHttpService{TPayload}" /> for 'single' mime-type http requests
   /// </summary>
   internal class SendHttpService4SingleContent : SendHttpServiceBase<SingleContentPayload>
   {
      private readonly IHttpSender _httpMessageService;

      #region ctor

      public SendHttpService4SingleContent() : this(new HttpSender())
      {
      }

      internal SendHttpService4SingleContent(IHttpSender httpMessageService)
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