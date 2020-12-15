using NUnit.Framework;

namespace Tch.RestClient.IntTests.UseCases.Put.ExternalSystemOffline
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