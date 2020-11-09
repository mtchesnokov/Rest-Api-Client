using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntraOffice.Nuget.HttpClient.Interfaces
{
   /// <summary>
   ///    Service to send 'PATCH' http requests
   /// </summary>
   public interface IHttpPatchService<THttpResponse>
   {
      Task<THttpResponse> PatchModel<TModel>(string url, TModel model, Dictionary<string, string> httpHeaders = null);

      Task<THttpResponse> PatchJson(string url, string jsonText, Dictionary<string, string> httpHeaders = null);
   }
}