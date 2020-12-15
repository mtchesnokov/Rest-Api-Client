using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Interfaces.Helpers
{
   /// <summary>
   ///    This interface represents http service that constructs http requests
   ///    based on provided input and sends to the destination url
   /// </summary>
   /// <typeparam name="TPayload">Type of payload</typeparam>
   internal interface ISendHttpService<TPayload>
   {
      Task<HttpResponseMessage> Send(HttpMethod httpMethod, string url, TPayload payload, RestClientOptions restClientOptions = null);
   }
}