using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Helpers;
using Tch.HttpClient.Interfaces.Basic;
using Tch.HttpClient.Interfaces.Internals;
using Tch.HttpClient.Services.Helpers1;

namespace Tch.HttpClient.Services.Internals
{
   internal class HttpPatchServiceInternal : IHttpPatchServiceInternal
   {
      private readonly IHttpService<SingleContentHttpRequest> _singleTypeHttpService;

      #region ctor

      public HttpPatchServiceInternal(IHttpService<SingleContentHttpRequest> singleTypeHttpService)
      {
         _singleTypeHttpService = singleTypeHttpService ?? throw new ArgumentNullException(nameof(singleTypeHttpService));
      }

      #endregion

      public Task<HttpResponseMessage> Patch(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         var request = jsonText.ToSingleContentHttpRequest(httpHeaders);
         return _singleTypeHttpService.Send(new HttpMethod("PATCH"), url, request);
      }
   }
}