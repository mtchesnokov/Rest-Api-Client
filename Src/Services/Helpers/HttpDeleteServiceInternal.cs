using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IntraOffice.Nuget.HttpClient.Domain.Helpers;
using IntraOffice.Nuget.HttpClient.Interfaces.Helpers;
using IntraOffice.Nuget.HttpClient.Interfaces.Helpers1;
using IntraOffice.Nuget.HttpClient.Services.Helpers.StringExtensions;

namespace IntraOffice.Nuget.HttpClient.Services.Helpers
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

      public async Task<HttpResponseMessage> DeleteJson(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         var request = jsonText.ToSingleContentHttpRequest(httpHeaders);
         var httpResponseMessage = await _singleTypeHttpService.Send(HttpMethod.Delete, url, request);
         return httpResponseMessage;
      }
   }
}