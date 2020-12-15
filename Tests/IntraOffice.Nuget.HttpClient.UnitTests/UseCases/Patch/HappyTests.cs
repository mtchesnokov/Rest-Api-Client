using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces;
using Tch.RestClient.UnitTests.TestExtensions;

namespace Tch.RestClient.UnitTests.UseCases.Patch
{
   public class HappyTests : UnitTestBase<IRestClient>
   {
      [Test]
      public async Task No_Content()
      {
         //arrange
         var url = "http://someurl";
         var httpHeaders = new Dictionary<string, string>
         {
            {"Authorization", "Bearer XXX"}
         };

         this.SetupResponse(HttpStatusCode.OK, obj: new {Message = "Hi there"});

         //assert
         var responseDto = await SUT().Patch(url, httpHeaders);

         //print
         responseDto.Print();
      }

      [Test]
      public async Task Json_Content()
      {
         //arrange
         var url = "http://someurl";
         var jsonText = JsonConvert.SerializeObject(new {Message = "Hello"});
         var httpHeaders = new Dictionary<string, string>
         {
            {"Authorization", "Bearer XXX"}
         };

         this.SetupResponse(HttpStatusCode.OK, obj: new {Message = "Hi there"});

         //assert
         var responseDto = await SUT().Patch(url, jsonText, httpHeaders);

         //print
         responseDto.Print();
      }


      [Test]
      public async Task Mixed_Content()
      {
         //arrange
         var url = "http://someurl";
         var jsonText = JsonConvert.SerializeObject(new {Message = "Hello"});
         FileVm[] files = {this.GetEmbeddedFile("Welcome.pdf")};
         var httpHeaders = new Dictionary<string, string>
         {
            {"Authorization", "Bearer XXX"}
         };

         this.SetupResponse(HttpStatusCode.OK, obj: new {Message = "Hi there"});

         //assert
         var responseDto = await SUT().Patch(url, jsonText, files, httpHeaders);

         //print
         responseDto.Print();
      }
   }
}