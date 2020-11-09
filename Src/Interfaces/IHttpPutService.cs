using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tch.HttpClient.Interfaces
{
   /// <summary>
   ///    Service to send 'PUT' http requests
   /// </summary>
   public interface IHttpPutService
   {
      Task<THttpResponse> PutModel<THttpResponse>(string url, object model = null, Dictionary<string, string> httpHeaders = null);

      Task<THttpResponse> PutJson<THttpResponse>(string url, string jsonText = null, Dictionary<string, string> httpHeaders = null);
   }
}