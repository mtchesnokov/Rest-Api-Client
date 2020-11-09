using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Tch.HttpClient.Interfaces;

namespace Tch.HttpClient.IntTests.UseCases.Automatic.Post
{
   [Category("EndToEnd")]
   [Explicit]
   public class Post2ControllerTests : IntegrationTestBase<IHttpPostService<FakeCreatedModel>>
   {
      [Test]
      [TestCase("/post2")]
      public async Task Post_Model_With_Files(string relativeUrl)
      {
         //arrange
         var url = this.GetUrl(relativeUrl);
         var httpHeaders = new Dictionary<string, string> {{"X-Tenant", "dummy"}};
         var model = new FakeCreateModel {Name = "Dummy"};
         var files = new List<OwnFile> {this.GetEmbeddedOwnFile("Welcome.pdf")};

         //act
         var createdModel = await SUT().PostModel(url, model, files, httpHeaders);

         //assert
         Assert.IsNotNull(createdModel);

         //print
         createdModel.Print();
      }
   }
}