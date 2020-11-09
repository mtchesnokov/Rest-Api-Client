using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Helpers;
using Tch.HttpClient.Interfaces.Basic;
using Tch.HttpClient.Interfaces.Helpers;
using Tch.HttpClient.Services.Helpers1;

namespace Tch.HttpClient.Services.Helpers
{
   internal class HttpPutServiceInternal : IHttpPutServiceInternal
   {
      private readonly IHttpService<SingleContentHttpRequest> _singleTypeHttpService;

      #region ctor

      public HttpPutServiceInternal(IHttpService<SingleContentHttpRequest> singleTypeHttpService)
      {
         _singleTypeHttpService = singleTypeHttpService ?? throw new ArgumentNullException(nameof(singleTypeHttpService));
      }

      #endregion

      public Task<HttpResponseMessage> Put(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         var request = jsonText.ToSingleContentHttpRequest(httpHeaders);
         return _singleTypeHttpService.Send(HttpMethod.Put, url, request);
      }
   }
}