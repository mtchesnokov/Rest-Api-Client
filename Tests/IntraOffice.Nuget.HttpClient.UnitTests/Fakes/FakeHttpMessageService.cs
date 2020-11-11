using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.UnitTests.TestExtensions;
using Tch.RestClient.Domain.Objects;

namespace Tch.HttpClient.UnitTests.Fakes
{
   public class FakeHttpMessageService : IHttpMessageService
   {
      public HttpResponseMessage HttpResponseMessage { get; set; }

      public Task<HttpResponseMessage> Send(HttpRequestMessage requestMessage, RestClientOptions restClientOptions)
      {
         Debug.WriteLine("HttpRequest:");
         requestMessage.Print();

         Debug.WriteLine("HttpClientOptions:");
         restClientOptions.Print();

         return Task.FromResult(HttpResponseMessage);
      }
   }
}