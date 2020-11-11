using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Exceptions;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces.Basic;

namespace Tch.RestClient.Services.Basic
{
   internal class HttpMessageService : IHttpService
   {
      public async Task<HttpResponseMessage> Send(HttpRequestMessage httpRequestMessage, RestClientOptions restClientOptions)
      {
         var httpMethod = httpRequestMessage.Method.ToString();
         var requestUrl = httpRequestMessage.RequestUri.ToString();
         var connectionTimeoutSeconds = restClientOptions.ConnectionTimeoutSeconds;

         using (var client = new HttpClient {Timeout = TimeSpan.FromSeconds(connectionTimeoutSeconds)})
         {
            HttpResponseMessage httpResponseMessage;

            try
            {
               httpResponseMessage = await client.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead);
            }
            catch (TaskCanceledException)
            {
               throw new ExternalServiceTimeoutException
               {
                  ServiceUrl = requestUrl,
                  TimeoutSeconds = connectionTimeoutSeconds,
                  UsedHttpMethod = httpMethod
               };
            }

            return httpResponseMessage;
         }
      }
   }
}