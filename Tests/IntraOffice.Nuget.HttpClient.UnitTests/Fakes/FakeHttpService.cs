using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces.Basic;
using Tch.RestClient.UnitTests.TestExtensions;

namespace Tch.RestClient.UnitTests.Fakes
{
   public class FakeHttpService : IHttpService
   {
      public HttpResponseMessage HttpResponseMessage { get; set; }

      public Task<HttpResponseMessage> Send(HttpRequestMessage requestMessage, RestClientOptions restClientOptions)
      {
         requestMessage.Print();

         restClientOptions.Print();

         return Task.FromResult(HttpResponseMessage);
      }
   }
}