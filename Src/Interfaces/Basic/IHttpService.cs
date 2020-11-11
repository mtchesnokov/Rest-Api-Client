using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Interfaces.Basic
{
   /// <summary>
   ///    This interface represents http service that can send both single mime-type and multiple mime-type requests
   /// </summary>
   /// <typeparam name="TRequest">Type of http request</typeparam>
   internal interface IHttpService<TRequest>
   {
      Task<HttpResponseMessage> Send(HttpMethod httpMethod, string url, TRequest request, RestClientOptions restClientOptions = null);
   }
}