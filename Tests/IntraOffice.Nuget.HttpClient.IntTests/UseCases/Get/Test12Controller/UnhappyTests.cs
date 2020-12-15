using NUnit.Framework;
using Tch.RestClient.Interfaces;
using Tch.RestClient.IntTests.TestExtensions;

namespace Tch.RestClient.IntTests.UseCases.Get.Test12Controller
{
   [Category("EndToEnd")]
   [Explicit]
   public class UnhappyTests : IntegrationTestBase<IRestClient>
   {
      [Test]
      [TestCase("/test12")]
      public void BadRequest_Returned(string relativeUrl)
      {
         //arrange
         var url = this.GetUrl(relativeUrl);

         //assert
         MyAssert.ThrowsAsync<ExternalServiceHttpException>(() => SUT().GetObject<string>(url));
      }
   }
}