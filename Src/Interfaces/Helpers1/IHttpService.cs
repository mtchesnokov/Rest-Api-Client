using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Objects;

namespace Tch.HttpClient.Interfaces.Helpers1
{
   /// <summary>
   ///    This interface represents handy decorator service to send single/multi content-type http requests
   ///    That hides http internals from calling code
   /// </summary>
   /// <typeparam name="TRequest">Type of http request</typeparam>
   internal interface IHttpService<TRequest>
   {
      Task<HttpResponseMessage> Send(HttpMethod httpMethod, string url, TRequest request, HttpClientOptions httpClientOptions = null);
   }
}