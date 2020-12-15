using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Tch.RestClient.Interfaces;
using Tch.RestClient.IntTests.TestExtensions;

namespace Tch.RestClient.IntTests.UseCases.Get.Test13Controller
{
   [Category("EndToEnd")]
   [Explicit]
   public class HappyTests : IntegrationTestBase<IRestClient>
   {
      [Test]
      [TestCase("/test13")]
      public async Task File_Returned(string relativeUrl)
      {
         //arrange
         var url = this.GetUrl(relativeUrl);

         //act
         var response = await SUT().GetFile(url);

         //assert
         CollectionAssert.IsNotEmpty(response.Content);

         //print
         response.Print();
         Console.WriteLine(response.Content.Length);
      }
   }
}