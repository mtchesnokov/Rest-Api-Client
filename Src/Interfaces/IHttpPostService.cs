using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Objects;

namespace Tch.HttpClient.Interfaces
{
   /// <summary>
   /// Service to send 'POST' http requests
   /// </summary>
   public interface IHttpPostService
   {
      Task<HttpResponseMessage> PostJson(string url, string jsonText, Dictionary<string, string> httpHeaders = null, HttpClientOptions httpClientOptions = null);

      Task<HttpResponseMessage> PostJson(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders = null, HttpClientOptions httpClientOptions = null);
   }

   /// <summary>
   ///    Service to send 'POST' http requests
   /// </summary>
   public interface IHttpPostService<TResponse>
   {
      Task<TResponse> PostModel<TModel>(string url, TModel model, Dictionary<string, string> httpHeaders = null, HttpClientOptions httpClientOptions = null);

      Task<TResponse> PostModel<TModel>(string url, TModel model, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders = null, HttpClientOptions httpClientOptions = null);

      Task<TResponse> PostJson(string url, string jsonText, Dictionary<string, string> httpHeaders = null, HttpClientOptions httpClientOptions = null);

      Task<TResponse> PostJson(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders = null, HttpClientOptions httpClientOptions = null);
   }
}