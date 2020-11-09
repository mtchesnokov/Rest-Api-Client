using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntraOffice.Nuget.HttpClient.Interfaces
{
   /// <summary>
   ///    This represents a handy decorator service to send 'DELETE' http requests
   /// </summary>
   public interface IHttpDeleteService<THttpResponse>
   {
      Task<THttpResponse> DeleteModel<TModel>(string url, TModel model = null, Dictionary<string, string> httpHeaders = null) where TModel : class;

      Task<THttpResponse> DeleteJson(string url, string jsonText = null, Dictionary<string, string> httpHeaders = null);
   }
}