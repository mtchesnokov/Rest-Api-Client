using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Exceptions;
using Tch.HttpClient.Domain.Objects;
using Tch.HttpClient.Interfaces.Helpers1;

namespace Tch.HttpClient.Services.Helpers1
{
   internal class HttpMessageService : IHttpMessageService
   {
      [SetterProperty]
      public IOwnAppLogService OwnAppLogService { get; set; }

      public async Task<HttpResponseMessage> Send(HttpRequestMessage httpRequestMessage, HttpClientOptions httpClientOptions)
      {
         var httpMethod = httpRequestMessage.Method.ToString();
         var requestUrl = httpRequestMessage.RequestUri.ToString();
         var connectionTimeoutSeconds = httpClientOptions.ConnectionTimeoutSeconds;

         var eventData = new {httpMethod, requestUrl, connectionTimeoutSeconds};

         using (var client = new System.Net.Http.HttpClient {Timeout = TimeSpan.FromSeconds(connectionTimeoutSeconds)})
         {
            OwnAppLogService.LogDebug("Start sending http request to external service", eventData);

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            HttpResponseMessage httpResponseMessage;

            try
            {
               httpResponseMessage = await client.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead);
            }
            catch (TaskCanceledException)
            {
               OwnAppLogService.LogWarning("No Http response from external service have been received within expected timeout", eventData);

               throw new ExternalServiceTimeoutException
               {
                  ServiceUrl = requestUrl,
                  TimeoutSeconds = connectionTimeoutSeconds,
                  UsedHttpMethod = httpMethod
               };
            }

            stopWatch.Stop();

            var millisecondsPassed = stopWatch.ElapsedMilliseconds;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
               OwnAppLogService.LogDebug($"Http response from external service has been received after {millisecondsPassed} milliseconds",
                  new { method = httpMethod, url = requestUrl, responeStatusCode = ((int)httpResponseMessage.StatusCode).ToString() });
            }
            else
            {
               OwnAppLogService.LogWarning($"Error response code from external service has been received after {millisecondsPassed} milliseconds",
                  new { method = httpMethod, url = requestUrl, responeStatusCode = ((int)httpResponseMessage.StatusCode).ToString() });
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