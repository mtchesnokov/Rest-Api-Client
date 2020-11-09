using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Exceptions;
using Tch.HttpClient.Domain.Objects;
using Tch.HttpClient.Interfaces.Helpers1;

namespace Tch.HttpClient.Services.Helpers1
{
   internal abstract class HttpServiceBase<TRequest> : IHttpService<TRequest>
   {
      public async Task<HttpResponseMessage> Send(HttpMethod httpMethod, string url, TRequest request, HttpClientOptions httpClientOptions)
      {
         if (httpClientOptions == null)
         {
            httpClientOptions = new HttpClientOptions();
         }

         var httpResponseMessage = await SendImpl(httpMethod, url, request, httpClientOptions);

         if (!httpResponseMessage.IsSuccessStatusCode)
         {
            throw new ExternalServiceHttpException
            {
               UsedHttpMethod = httpMethod.Method,
               ServiceUrl = url,
               ReturnedStatusCode = httpResponseMessage.StatusCode.ToString(),
               ReasonPhrase = httpResponseMessage.ReasonPhrase
            };
         }

         return httpResponseMessage;
      }

      protected abstract Task<HttpResponseMessage> SendImpl(HttpMethod httpMethod, string url, TRequest request, HttpClientOptions httpClientOptions);
   }
}