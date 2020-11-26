using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Interfaces.Basic
{
   /// <summary>
   ///    This interface represents low level service to send http requests
   /// </summary>
   internal interface IHttpSender
   {
      Task<HttpResponseMessage> Send(HttpRequestMessage httpRequestMessage, RestClientOptions restClientOptions);
   }
}