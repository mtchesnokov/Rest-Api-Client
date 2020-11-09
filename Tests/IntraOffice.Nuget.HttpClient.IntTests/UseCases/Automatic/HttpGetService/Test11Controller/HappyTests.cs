using System.Threading.Tasks;
using IntraOffice.Nuget.HttpClient.Interfaces;
using IntraOffice.Nuget.HttpClient.IntTests.Fakes;
using IntraOffice.Nuget.HttpClient.IntTests.TestExtensions;
using IntraOffice.Nuget.Testing.Abstractions.ObjectExtensions;
using IntraOffice.Nuget.Testing.Abstractions;
using NUnit.Framework;

namespace IntraOffice.Nuget.HttpClient.IntTests.UseCases.Automatic.HttpGetService.Test11Controller
{
   [Category("EndToEnd")]
   [Explicit]
   public class HappyTests : IntegrationTestBase<IHttpGetService>
   {
      [Test]
      [TestCase("/test11")]
      public async Task Model_Returned(string relativeUrl)
      {
         //arrange
         var url = this.GetUrl(relativeUrl);

         //act
         var result = await SUT().GetObject<FakeModel>(url);

         //assert
         Assert.AreEqual(123, result.Id);
         Assert.AreEqual("Dummy", result.Name);

         //print
         result.Print();
      }
   }
}