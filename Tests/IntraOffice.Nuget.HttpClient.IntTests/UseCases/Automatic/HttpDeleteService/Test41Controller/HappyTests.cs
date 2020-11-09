using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using IntraOffice.Nuget.HttpClient.Domain.Objects;
using IntraOffice.Nuget.HttpClient.Interfaces;
using IntraOffice.Nuget.HttpClient.IntTests.Fakes;
using IntraOffice.Nuget.HttpClient.IntTests.TestExtensions;
using IntraOffice.Nuget.Testing.Abstractions;
using IntraOffice.Nuget.Testing.Abstractions.ObjectExtensions;
using NUnit.Framework;

namespace IntraOffice.Nuget.HttpClient.IntTests.UseCases.Automatic.HttpDeleteService.Test41Controller
{
   [Category("EndToEnd")]
   [Explicit]
   public class HappyTests : IntegrationTestBase<IHttpDeleteService<HttpResponseVm1>>
   {
      [Test]
      [TestCase("/test41")]
      public async Task Delete_Model(string relativeUrl)
      {
         //arrange
         var url = this.GetUrl(relativeUrl);
         var httpHeaders = new Dictionary<string, string> {{"X-Tenant", "dummy"}};
         var model = new FakeCreateModel {Name = "Dummy"};

         //act
         var response = await SUT().DeleteModel(url, model, httpHeaders);

         //assert
         Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

         //print
         response.Print();
      }
   }
}