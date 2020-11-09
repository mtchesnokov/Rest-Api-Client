using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IntraOffice.Nuget.HttpClient.Domain.Helpers;
using IntraOffice.Nuget.HttpClient.Interfaces.Helpers;
using IntraOffice.Nuget.HttpClient.Interfaces.Helpers1;
using IntraOffice.Nuget.HttpClient.Services.Helpers.StringExtensions;

namespace IntraOffice.Nuget.HttpClient.Services.Helpers
{
   /// <summary>
   ///    Implementation of <see cref="IHttpPatchServiceInternal" />
   /// </summary>
   internal class HttpPatchServiceInternal : IHttpPatchServiceInternal
   {
      private readonly IHttpService<SingleContentHttpRequest> _singleTypeHttpService;

      #region ctor

      public HttpPatchServiceInternal(IHttpService<SingleContentHttpRequest> singleTypeHttpService)
      {
         _singleTypeHttpService = singleTypeHttpService ?? throw new ArgumentNullException(nameof(singleTypeHttpService));
      }

      #endregion

      public async Task<HttpResponseMessage> PatchJson(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         var request = jsonText.ToSingleContentHttpRequest(httpHeaders);
         return await _singleTypeHttpService.Send(new HttpMethod("PATCH"), url, request);
      }
   }
}