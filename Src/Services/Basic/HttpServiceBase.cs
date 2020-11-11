using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces.Basic;

namespace Tch.RestClient.Services.Basic
{
   internal abstract class HttpServiceBase<TRequest> : IHttpService<TRequest>
   {
      public Task<HttpResponseMessage> Send(HttpMethod httpMethod, string url, TRequest request, RestClientOptions restClientOptions)
      {
         if (restClientOptions == null)
         {
            restClientOptions = new RestClientOptions();
         }

         return SendImpl(httpMethod, url, request, restClientOptions);
      }

      protected abstract Task<HttpResponseMessage> SendImpl(HttpMethod httpMethod, string url, TRequest request, RestClientOptions restClientOptions);
   }
}