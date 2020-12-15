using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Tch.RestClient.Interfaces;
using Tch.RestClient.IntTests.TestExtensions;

namespace Tch.RestClient.IntTests.UseCases.Get.Test1Controller
{
   [Category("EndToEnd")]
   [Explicit]
   public class HappyTests : IntegrationTestBase<IRestClient>
   {
      [Test]
      [TestCase("/test1")]
      public async Task String_Returned(string relativeUrl)
      {
         //arrange
         var url = this.GetUrl(relativeUrl);
         var httpHeaders = new Dictionary<string, string> {{"X-Tenant", "dummy"}};

         //act
         var response = await SUT().GetObject<string>(url, httpHeaders);

         //assert
         Assert.AreEqual("Hello world", response);

         //print
         response.Print();
      }
   }
}