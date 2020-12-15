using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tch.RestClient.IntTests.UseCases.Post
{
   [Category("EndToEnd")]
   [Explicit]
   public class Post1ControllerTests : IntegrationTestBase<IHttpPostService<FakeCreatedModel>>
   {
      [Test]
      [TestCase("/post1")]
      public async Task Post_Model(string relativeUrl)
      {
         //arrange
         var url = this.GetUrl(relativeUrl);
         var httpHeaders = new Dictionary<string, string> {{"X-Tenant", "dummy"}};
         var model = new FakeCreateModel {Name = "Dummy"};

         //act
         var createdModel = await SUT().PostModel(url, model, httpHeaders);

         //assert
         Assert.IsNotNull(createdModel);

         //print
         createdModel.Print();
      }
   }
}