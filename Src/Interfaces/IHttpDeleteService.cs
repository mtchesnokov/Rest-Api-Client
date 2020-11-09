using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tch.HttpClient.Interfaces
{
   /// <summary>
   ///    This represents a handy decorator service to send 'DELETE' http requests
   /// </summary>
   public interface IHttpDeleteService
   {
      Task<THttpResponse> DeleteModel<THttpResponse>(string url, object model = null, Dictionary<string, string> httpHeaders = null);

      Task<THttpResponse> DeleteJson<THttpResponse>(string url, string jsonText = null, Dictionary<string, string> httpHeaders = null);
   }
}