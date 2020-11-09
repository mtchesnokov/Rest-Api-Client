using IntraOffice.Nuget.HttpClient.Domain.Exceptions;
using IntraOffice.Nuget.HttpClient.Interfaces;
using IntraOffice.Nuget.HttpClient.IntTests.Fakes;
using IntraOffice.Nuget.Testing.Abstractions;
using IntraOffice.Nuget.Testing.Abstractions.Helpers;
using NUnit.Framework;

namespace IntraOffice.Nuget.HttpClient.IntTests.UseCases.Manual.HttpGetService.ExternalSystemOffline
{
   [Explicit]
   [Category("IntegrationTest")]
   public class UnhappyTests : TestBase<IHttpGetService>
   {
      [Test]
      public void Gateway_Offline()
      {
         //arrange
         var badUrl = "http://localhost.fiddler:12345";

         //act                  
         MyAssert.ThrowsAsync<ExternalServiceOfflineException>(() => SUT().GetObject<FakeModel>(badUrl));
      }
   }
}