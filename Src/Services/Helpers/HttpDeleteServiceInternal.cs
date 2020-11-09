using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Helpers;
using Tch.HttpClient.Interfaces.Basic;
using Tch.HttpClient.Interfaces.Helpers;
using Tch.HttpClient.Services.Helpers1;

namespace Tch.HttpClient.Services.Helpers
{
   internal class HttpDeleteServiceInternal : IHttpDeleteServiceInternal
   {
      private readonly IHttpService<SingleContentHttpRequest> _singleTypeHttpService;

      #region ctor

      public HttpDeleteServiceInternal(IHttpService<SingleContentHttpRequest> singleTypeHttpService)
      {
         _singleTypeHttpService = singleTypeHttpService;
      }

      #endregion

      public Task<HttpResponseMessage> Delete(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         var request = jsonText.ToSingleContentHttpRequest(httpHeaders);
         return _singleTypeHttpService.Send(HttpMethod.Delete, url, request);
      }
   }
}