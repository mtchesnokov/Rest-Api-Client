using System.Net.Http;
using Tch.RestClient.Interfaces.Basic;
using Tch.RestClient.UnitTests.Fakes;
using Tch.RestClient.UnitTests.UseCases;

namespace Tch.RestClient.UnitTests.TestExtensions
{
   public static class SetupResponseExtension
   {
      public static void SetupResponse(this UnitTestBase test, HttpResponseMessage httpResponseMessage)
      {
         IHttpService fakeHttpService = new FakeHttpService {HttpResponseMessage = httpResponseMessage};

         test.Container.EjectAllInstancesOf<IHttpService>();

         test.Container.Inject(typeof(IHttpService), fakeHttpService);
      }
   }
}