using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.HttpClient.Interfaces;
using IntraOffice.Nuget.HttpClient.IntTests.TestExtensions;
using IntraOffice.Nuget.Testing.Abstractions.ObjectExtensions;
using IntraOffice.Nuget.Testing.Abstractions;
using NUnit.Framework;

namespace IntraOffice.Nuget.HttpClient.IntTests.UseCases.Automatic.HttpGetService.Test1Controller
{
   [Category("EndToEnd")]
   [Explicit]
   public class HappyTests : IntegrationTestBase<IHttpGetService>
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