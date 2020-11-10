using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces;
using Tch.RestClient.Interfaces.Basic;
using Tch.RestClient.Services.Basic;

namespace Tch.RestClient.Services
{
   public class RestClient : IRestClient
   {
      private readonly IHttpClientInternal _innerService;

      #region ctor

      public RestClient() : this(new HttpClientInternal())
      {
      }

      internal RestClient(IHttpClientInternal innerService)
      {
         _innerService = innerService;
      }

      #endregion

      public Task<ResponseVm> Put(string url, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(HttpMethod.Put, url, httpHeaders);
      }

      public Task<ResponseVm> Put(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(HttpMethod.Put, url, jsonText, httpHeaders);
      }

      public Task<ResponseVm> Put(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(HttpMethod.Put, url, jsonText, files, httpHeaders);
      }
   }
}