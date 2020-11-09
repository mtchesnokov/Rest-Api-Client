using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Objects;
using Tch.HttpClient.UnitTests.TestExtensions;

namespace Tch.HttpClient.UnitTests.Fakes
{
   public class FakeHttpMessageService : IHttpMessageService
   {
      public HttpResponseMessage HttpResponseMessage { get; set; }

      public Task<HttpResponseMessage> Send(HttpRequestMessage requestMessage, HttpClientOptions httpClientOptions)
      {
         Debug.WriteLine("HttpRequest:");
         requestMessage.Print();

         Debug.WriteLine("HttpClientOptions:");
         httpClientOptions.Print();

         return Task.FromResult(HttpResponseMessage);
      }
   }
}