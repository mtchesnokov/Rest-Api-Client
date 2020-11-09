using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Abstractions.Domain.Objects;

namespace IntraOffice.Nuget.HttpClient.Interfaces
{
   /// <summary>
   ///    Service to send 'PUT' http requests
   /// </summary>
   public interface IHttpPutService<THttpResponse>
   {
      Task<THttpResponse> PutModel<TModel>(string url, TModel model, Dictionary<string, string> httpHeaders = null);

      Task<THttpResponse> PutModel<TModel>(string url, TModel model, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders = null);

      Task<THttpResponse> PutJson(string url, string jsonText, Dictionary<string, string> httpHeaders = null);

      Task<THttpResponse> PutJson(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders = null);
   }
}