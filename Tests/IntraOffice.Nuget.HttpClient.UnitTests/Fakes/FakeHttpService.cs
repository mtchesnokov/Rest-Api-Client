using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces.Helpers;
using Tch.RestClient.UnitTests.TestExtensions;

namespace Tch.RestClient.UnitTests.Fakes
{
   public class FakeHttpService : IHttpSender
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