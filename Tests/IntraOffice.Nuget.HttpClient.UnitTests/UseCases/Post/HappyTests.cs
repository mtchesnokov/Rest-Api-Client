using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using Tch.HttpClient.Domain.Objects;
using Tch.HttpClient.Interfaces;
using Tch.HttpClient.UnitTests.Fakes;
using Tch.HttpClient.UnitTests.TestExtensions;

namespace Tch.HttpClient.UnitTests.UseCases.Post
{
   public class HappyTests : OwnUnitTestBase<IHttpPostService<FakeResponse>>
   {
      [Test]
      public async Task PostModel()
      {
         //arrange
         var url = "http://fake.com";
         var model = new FakeModel {Id = "abc", Name = "efg"};
         SetupResponse(HttpStatusCode.OK, new FakeResponse {Message = "Hello"});
         var httpHeaders = new Dictionary<string, string> {{"X-Tenant", "Dummy"}};
         var httpClientOptions = new HttpClientOptions(123);

         //act        
         var response = await SUT().PostModel(url, model, httpHeaders, httpClientOptions);

         //assert
         Assert.IsNotNull(response);

         //print 
         response.Print();
      }
   }
}