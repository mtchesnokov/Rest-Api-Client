using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using Tch.RestClient.Interfaces;
using Tch.RestClient.UnitTests.TestExtensions;

namespace Tch.RestClient.UnitTests.UseCases.Get
{
   public class HappyTests : UnitTestBase<IRestClient>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         this.SetupResponse(HttpStatusCode.OK, "OK", new {Message = "Hello world"});
         var url = "http://someurl";
         var httpHeaders = new Dictionary<string, string>
         {
            {"Authorization", "Bearer XXX"}
         };

         //assert
         var responseDto = await SUT().Get(url, httpHeaders);

         //print
         responseDto.Print();
      }
   }
}