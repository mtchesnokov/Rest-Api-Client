using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Helpers;
using Tch.HttpClient.Domain.Objects;
using Tch.HttpClient.Interfaces;
using Tch.HttpClient.Interfaces.Basic;
using Tch.HttpClient.Services.Helpers1;

namespace Tch.HttpClient.Services
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
   }
}