using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IntraOffice.Nuget.HttpClient.Domain.Helpers;
using IntraOffice.Nuget.HttpClient.Interfaces.Helpers;
using IntraOffice.Nuget.HttpClient.Interfaces.Helpers1;

namespace IntraOffice.Nuget.HttpClient.Services.Helpers
{
   /// <summary>
   ///    Implementation of <see cref="IHttpGetServiceInternal" />
   /// </summary>
   internal class HttpGetServiceInternal : IHttpGetServiceInternal
   {
      private readonly IHttpService<SingleContentHttpRequest> _httpService;

      #region ctor

      public HttpGetServiceInternal(IHttpService<SingleContentHttpRequest> httpService)
      {
         _httpService = httpService;
      }

      #endregion

      public async Task<HttpResponseMessage> Get(string url, Dictionary<string, string> httpHeaders = null)
      {
         var request = new SingleContentHttpRequest {HttpHeaders = httpHeaders};
         var httpResponseMessage = await _httpService.Send(HttpMethod.Get, url, request);
         return httpResponseMessage;
      }
   }
}