using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Interfaces
{
   /// <summary>
   ///    Service to send 'POST' http requests
   /// </summary>
   public interface IHttpPostService
   {
      Task<THttpResponse> PostJson<THttpResponse>(string url, string jsonText = null, Dictionary<string, string> httpHeaders = null, HttpClientOptions httpClientOptions = null);

      Task<THttpResponse> PostModel<THttpResponse>(string url, object model = null, Dictionary<string, string> httpHeaders = null, HttpClientOptions httpClientOptions = null);
   }
}