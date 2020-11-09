using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Objects;
using Tch.HttpClient.Interfaces.Basic;

namespace Tch.HttpClient.Services.Basic
{
   internal abstract class HttpServiceBase<TRequest> : IHttpService<TRequest>
   {
      public Task<HttpResponseMessage> Send(HttpMethod httpMethod, string url, TRequest request, HttpClientOptions httpClientOptions)
      {
         if (httpClientOptions == null)
         {
            httpClientOptions = new HttpClientOptions();
         }

         return SendImpl(httpMethod, url, request, httpClientOptions);
      }

      protected abstract Task<HttpResponseMessage> SendImpl(HttpMethod httpMethod, string url, TRequest request, HttpClientOptions httpClientOptions);
   }
}