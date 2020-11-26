using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Tch.RestClient.Interfaces.Basic;
using Tch.RestClient.UnitTests.Fakes;

namespace Tch.RestClient.UnitTests.TestExtensions
{
   public static class SetupResponseExtension
   {
      public static void SetupResponse(this UnitTestBase test, HttpResponseMessage httpResponseMessage)
      {
         IHttpSender fakeHttpService = new FakeHttpService {HttpResponseMessage = httpResponseMessage};
         test.Container.EjectAllInstancesOf<IHttpSender>();
         test.Container.Inject(typeof(IHttpSender), fakeHttpService);
      }

      public static void SetupResponse(this UnitTestBase test, HttpStatusCode httpStatusCode, string reasonPhrase = "OK", object obj = null)
      {
         var httpResponseMessage = new HttpResponseMessage(httpStatusCode) {ReasonPhrase = reasonPhrase};

         if (obj != null)
         {
            httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
         }

         test.SetupResponse(httpResponseMessage);
      }
   }
}