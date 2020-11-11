using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Tch.RestClient.Interfaces;
using Tch.RestClient.UnitTests.TestExtensions;

namespace Tch.RestClient.UnitTests.UseCases.Get
{
   public class HappyTests : UnitTestBase<IRestClient>
   {
      [Test]
      public async Task No_Http_Headers()
      {
         //arrange
         var url = "http://someurl";
         
         var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
         var obj = new {Message = "Hello world"};
         httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
         this.SetupResponse(httpResponseMessage);

         //assert
         var responseDto = await SUT().Get(url);

         //print
         responseDto.Print();
      }
   }
}