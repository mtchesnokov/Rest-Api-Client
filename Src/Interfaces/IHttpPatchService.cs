using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tch.RestClient.Interfaces
{
   /// <summary>
   ///    Service to send 'PATCH' http requests
   /// </summary>
   public interface IHttpPatchService
   {
      Task<THttpResponse> PatchModel<THttpResponse>(string url, object model = null, Dictionary<string, string> httpHeaders = null);

      Task<THttpResponse> PatchJson<THttpResponse>(string url, string jsonText = null, Dictionary<string, string> httpHeaders = null);
   }
}