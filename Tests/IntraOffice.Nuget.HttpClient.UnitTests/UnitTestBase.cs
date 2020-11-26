using System;
using NUnit.Framework;
using StructureMap;

namespace Tch.RestClient.UnitTests
{
   [TestFixture]
   public abstract class UnitTestBase
   {
      public IContainer Container { get; private set; }

      //protected FakeHttpMessageService _httpMessageService;

      [SetUp]
      public void SetUp()
      {
         Container = new Container(cfg => cfg.AddRegistry<MasterRegistry>());


         // _httpMessageService = this.OverwriteService<IHttpMessageService, FakeHttpMessageService>();
      }

      //protected void SetupResponse(HttpStatusCode statusCode, string responseBody)
      //{
      //   var responseContent = new StringContent(responseBody, Encoding.UTF8, "application/json");
      //   _httpMessageService.HttpResponseMessage = new HttpResponseMessage {Content = responseContent, StatusCode = statusCode};
      //}

      //protected void SetupResponse<TModel>(HttpStatusCode statusCode, TModel responseModel)
      //{
      //   var responseBody = JsonConvert.SerializeObject(responseModel);
      //   SetupResponse(statusCode, responseBody);
      //}
   }

   public abstract class UnitTestBase<TSUT> : UnitTestBase
   {
      protected Func<TSUT> SUT => () => Container.GetInstance<TSUT>();
   }
}