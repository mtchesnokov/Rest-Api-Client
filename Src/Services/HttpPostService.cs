using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Helpers;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces;
using Tch.RestClient.Interfaces.Basic;
using Tch.RestClient.Services.Extensions;

namespace Tch.RestClient.Services
{
   public class HttpPostService : IHttpPostService
   {
      private readonly IHttpService<SingleContentHttpRequest> _singleTypeHttpService;

      #region ctor

      #endregion

      public Task<HttpResponseMessage> PostJson(string url, string jsonText, Dictionary<string, string> httpHeaders, HttpClientOptions httpClientOptions)
      {
         var request = jsonText.ToSingleContentHttpRequest(httpHeaders);
         return _singleTypeHttpService.Send(HttpMethod.Post, url, request, httpClientOptions);
      }

      public Task<THttpResponse> PostJson<THttpResponse>(string url, string jsonText = null, Dictionary<string, string> httpHeaders = null, HttpClientOptions httpClientOptions = null)
      {
         throw new System.NotImplementedException();
      }

      public Task<THttpResponse> PostModel<THttpResponse>(string url, object model = null, Dictionary<string, string> httpHeaders = null, HttpClientOptions httpClientOptions = null)
      {
         throw new System.NotImplementedException();
      }
   }
}