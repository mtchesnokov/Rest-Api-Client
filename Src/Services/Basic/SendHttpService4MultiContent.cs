using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Helpers;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces.Basic;
using Tch.RestClient.Services.Extensions;

namespace Tch.RestClient.Services.Basic
{
   /// <summary>
   ///    This class is implementation of <see cref="ISendHttpService{TPayload}" /> for 'multiple' mime-type http requests
   /// </summary>
   internal class SendHttpService4MultiContent : SendHttpServiceBase<MultiContentPayload>
   {
      private readonly IHttpSender _httpMessageService;

      #region ctor

      public SendHttpService4MultiContent() : this(new HttpSender())
      {
      }

      internal SendHttpService4MultiContent(IHttpSender httpMessageService)
      {
         _httpMessageService = httpMessageService;
      }

      #endregion

      protected override Task<HttpResponseMessage> SendImpl(HttpMethod httpMethod, string url, MultiContentPayload request, RestClientOptions restClientOptions)
      {
         var multipartContent = new MultipartFormDataContent();

         foreach (var httpContent in request.HttpContents)
         {
            multipartContent.Add(httpContent);
         }

         var httpRequestMessage = new HttpRequestMessage(httpMethod, url);
         httpRequestMessage.Content = multipartContent;
         httpRequestMessage.AddHttpHeaders(request.HttpHeaders);
         return _httpMessageService.Send(httpRequestMessage, restClientOptions);
      }
   }
}