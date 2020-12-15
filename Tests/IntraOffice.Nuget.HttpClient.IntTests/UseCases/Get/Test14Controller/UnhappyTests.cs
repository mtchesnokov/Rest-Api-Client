using NUnit.Framework;
using Tch.RestClient.Interfaces;
using Tch.RestClient.IntTests.TestExtensions;

namespace Tch.RestClient.IntTests.UseCases.Get.Test14Controller
{
   [Category("EndToEnd")]
   [Explicit]
   public class UnhappyTests : IntegrationTestBase<IRestClient>
   {
      [Test]
      [TestCase("/test15")]
      public void BadRequest_Returned(string relativeUrl)
      {
         //arrange
         var url = this.GetUrl(relativeUrl);

         //assert
         MyAssert.ThrowsAsync<ExternalServiceHttpException>(() => SUT().GetFile(url));
      }
   }
}