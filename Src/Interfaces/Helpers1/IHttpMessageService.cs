using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Objects;

namespace Tch.HttpClient.Interfaces.Helpers1
{
   /// <summary>
   ///    This interface represents 'bottom' level service to send/receive raw http messages
   /// </summary>
   internal interface IHttpMessageService
   {
      Task<HttpResponseMessage> Send(HttpRequestMessage httpRequestMessage, HttpClientOptions httpClientOptions);
   }
}