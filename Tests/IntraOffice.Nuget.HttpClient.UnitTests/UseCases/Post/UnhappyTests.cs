using System;
using System.Net;
using NUnit.Framework;
using Tch.RestClient.Interfaces;
using Tch.RestClient.UnitTests.TestExtensions;

namespace Tch.RestClient.UnitTests.UseCases.Post
{
   public class UnhappyTests : UnitTestBase<IRestClient>
   {
      [Test]
      public void Url_Empty_String()
      {
         //arrange
         var url = "";
         this.SetupResponse(HttpStatusCode.OK);

         //assert
         var exception = Assert.ThrowsAsync<ArgumentNullException>(() => SUT().Post(url));

         //print
         exception.Print();
      }

      [Test]
      public void Json_Text_Empty_String()
      {
         //arrange
         var url = "http://someurl";
         var jsonText = "";
         this.SetupResponse(HttpStatusCode.OK);

         //assert
         var exception = Assert.ThrowsAsync<ArgumentNullException>(() => SUT().Post(url, jsonText));

         //print
         exception.Print();
      }
   }
}