using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Helpers;
using Tch.HttpClient.Interfaces.Basic;
using Tch.HttpClient.Interfaces.Helpers;
using Tch.HttpClient.Services.Basic;

namespace Tch.HttpClient.Services.Helpers
{
   internal class HttpGetServiceInternal : IHttpGetServiceInternal
   {
      private readonly IHttpService<SingleContentHttpRequest> _httpService;

      #region ctor

      public HttpGetServiceInternal() : this(new HttpService4SingleContentRequests())
      {
      }

      internal HttpGetServiceInternal(IHttpService<SingleContentHttpRequest> httpService)
      {
         _httpService = httpService;
      }

      #endregion

      public Task<HttpResponseMessage> Get(string url, Dictionary<string, string> httpHeaders = null)
      {
         var request = new SingleContentHttpRequest {HttpHeaders = httpHeaders};
         return _httpService.Send(HttpMethod.Get, url, request);
      }
   }
}