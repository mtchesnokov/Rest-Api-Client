using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Interfaces.Basic
{
   /// <summary>
   ///    This interface represents http service that can send both single mime-type and multiple mime-type requests
   /// </summary>
   /// <typeparam name="TPayload">Type of http request</typeparam>
   internal interface IHttpPayloadService<TPayload>
   {
      Task<HttpResponseMessage> Send(HttpMethod httpMethod, string url, TPayload payload, RestClientOptions restClientOptions = null);
   }
}