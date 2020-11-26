using NUnit.Framework;
using Tch.RestClient.Domain.Exceptions;

namespace Tch.RestClient.IntTests.UseCases.Automatic.Post
{
   [Category("EndToEnd")]
   [Explicit]
   public class Post3ControllerTests : IntegrationTestBase<IHttpPostService<FakeCreatedModel>>
   {
      [Test]
      [TestCase("/post3")]
      public void Internal_Server_Error_Returned(string relativeUrl)
      {
         //arrange
         var url = this.GetUrl(relativeUrl);
         var model = new FakeCreateModel {Name = "Dummy"};

         //act+assert
         var exception = Assert.ThrowsAsync<ExternalServiceErrorException>(() => SUT().PostModel(url, model));

         //print
         exception.Print();
      }
   }
}