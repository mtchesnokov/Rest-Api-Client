using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Tch.RestClient.Interfaces;
using Tch.RestClient.IntTests.TestExtensions;

namespace Tch.RestClient.IntTests.UseCases.Get
{
   public class GetModel
   {
      public int Id { get; set; }

      public string Name { get; set; }
   }

   [Category("EndToEnd")]
   [Explicit]
   public class HappyTests : IntegrationTestBase<IRestClient>
   {
      [Test]
      [TestCase("/get1")]
      public async Task Get1(string relativeUrl)
      {
         //arrange
         var url = this.GetUrl(relativeUrl);

         //act
         var result = await SUT().Get(url);

         //assert
         Assert.AreEqual(200, (int) result.StatusCode);
         Assert.AreEqual("OK", result.ReasonPhrase);
         Assert.AreEqual(true, result.IsSuccessStatusCode);
         var model = JsonConvert.DeserializeObject<GetModel>(result.ResponseBody);
         Assert.AreEqual(123, model.Id);
         Assert.AreEqual("Abc", model.Name);

         //print
         result.Print();
      }


      [Test]
      [TestCase("/get2")]
      public async Task Get2(string relativeUrl)
      {
         //arrange
         var url = this.GetUrl(relativeUrl);

         //act
         var result = await SUT().Get(url);

         //assert
         Assert.AreEqual(404, (int) result.StatusCode);
         Assert.AreEqual("Not Found", result.ReasonPhrase);
         Assert.AreEqual(false, result.IsSuccessStatusCode);
         Assert.IsTrue(string.IsNullOrEmpty(result.ResponseBody));

         //print
         result.Print();
      }
   }
}