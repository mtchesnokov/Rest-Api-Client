using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Exceptions;
using Tch.HttpClient.Domain.Objects;
using Tch.HttpClient.Interfaces.Basic;

namespace Tch.HttpClient.Services.Basic
{
   internal class HttpMessageService : IHttpMessageService
   {
      public async Task<HttpResponseMessage> Send(HttpRequestMessage httpRequestMessage, HttpClientOptions httpClientOptions)
      {
         var httpMethod = httpRequestMessage.Method.ToString();
         var requestUrl = httpRequestMessage.RequestUri.ToString();
         var connectionTimeoutSeconds = httpClientOptions.ConnectionTimeoutSeconds;

         using (var client = new System.Net.Http.HttpClient {Timeout = TimeSpan.FromSeconds(connectionTimeoutSeconds)})
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

            if (httpResponseMessage.StatusCode == HttpStatusCode.BadGateway || httpResponseMessage.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
               throw new ExternalServiceOfflineException
               {
                  HttpMethod = httpMethod,
                  ServiceUrl = requestUrl,
                  ReasonPhrase = httpResponseMessage.ReasonPhrase,
                  ResponseStatusCode = ((int) httpResponseMessage.StatusCode).ToString()
               };
            }

            return httpResponseMessage;
         }
      }
   }
}