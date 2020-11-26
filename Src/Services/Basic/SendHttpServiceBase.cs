using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Exceptions;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces.Basic;

namespace Tch.RestClient.Services.Basic
{
   internal abstract class SendHttpServiceBase<TPayload> : ISendHttpService<TPayload>
   {
      public async Task<HttpResponseMessage> Send(HttpMethod httpMethod, string url, TPayload payload, RestClientOptions restClientOptions)
      {
         if (restClientOptions == null)
         {
            restClientOptions = new RestClientOptions();
         }

         var httpResponseMessage = await SendImpl(httpMethod, url, payload, restClientOptions);

         if (httpResponseMessage.StatusCode == HttpStatusCode.BadGateway || httpResponseMessage.StatusCode == HttpStatusCode.ServiceUnavailable)
         {
            throw new ExternalServiceOfflineException
            {
               HttpMethod = httpMethod.ToString(),
               ServiceUrl = url,
               ReasonPhrase = httpResponseMessage.ReasonPhrase,
               ResponseStatusCode = ((int) httpResponseMessage.StatusCode).ToString()
            };
         }

         return httpResponseMessage;
      }

      protected abstract Task<HttpResponseMessage> SendImpl(HttpMethod httpMethod, string url, TPayload request, RestClientOptions restClientOptions);
   }
}