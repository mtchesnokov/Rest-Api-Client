using System.Net;
using System.Net.Http;
using NUnit.Framework;
using Tch.RestClient.Domain.Exceptions;
using Tch.RestClient.Interfaces;
using Tch.RestClient.UnitTests.TestExtensions;

namespace Tch.RestClient.UnitTests.UseCases.Post
{
   public class UnhappyTests : UnitTestBase<IRestClient>
   {
      [Test]
      public void Server_Offline()
      {
         //arrange
         var url = "http://someurl";
         var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
         this.SetupResponse(httpResponseMessage);

         //assert
         var exception = Assert.ThrowsAsync<ExternalServiceOfflineException>(() => SUT().Get(url));

         //print
         exception.Print();
      }
   }
}