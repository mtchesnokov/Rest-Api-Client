using System.Net;
using NUnit.Framework;
using Tch.HttpClient.UnitTests.Fakes;
using Tch.HttpClient.UnitTests.TestExtensions;
using Tch.RestClient.Domain.Exceptions;

namespace Tch.HttpClient.UnitTests.UseCases.Post
{
   public class UnhappyTests : OwnUnitTestBase<IHttpPostService<FakeResponse>>
   {
      [Test]
      public void Server_Offline()
      {
         //arrange
         var url = "http://someurl";
         var model = new FakeModel();
         SetupResponse(HttpStatusCode.ServiceUnavailable, string.Empty);

         //assert
         var exception = Assert.ThrowsAsync<ExternalServiceHttpException>(() => SUT().PostModel(url, model));

         //print
         exception.Print();
      }
   }
}