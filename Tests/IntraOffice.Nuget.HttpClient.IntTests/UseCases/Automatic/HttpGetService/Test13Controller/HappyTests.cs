using System;
using System.Threading.Tasks;
using IntraOffice.Nuget.HttpClient.Interfaces;
using IntraOffice.Nuget.HttpClient.IntTests.TestExtensions;
using IntraOffice.Nuget.Testing.Abstractions.ObjectExtensions;
using IntraOffice.Nuget.Testing.Abstractions;
using NUnit.Framework;

namespace IntraOffice.Nuget.HttpClient.IntTests.UseCases.Automatic.HttpGetService.Test13Controller
{
   [Category("EndToEnd")]
   [Explicit]
   public class HappyTests : IntegrationTestBase<IHttpGetService>
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