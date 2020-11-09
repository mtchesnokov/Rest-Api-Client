using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using Tch.HttpClient.Interfaces.Helpers1;
using Tch.HttpClient.UnitTests.Fakes;

namespace Tch.HttpClient.UnitTests.UseCases
{
   public abstract class OwnUnitTestBase : TestBase
   {
      protected FakeHttpMessageService _httpMessageService;

      [SetUp]
      public void SetUp2()
      {
         _httpMessageService = this.OverwriteService<IHttpMessageService, FakeHttpMessageService>();
      }

      protected void SetupResponse(HttpStatusCode statusCode, string responseBody)
      {
         var responseContent = new StringContent(responseBody, Encoding.UTF8, "application/json");
         _httpMessageService.HttpResponseMessage = new HttpResponseMessage {Content = responseContent, StatusCode = statusCode};
      }

      protected void SetupResponse<TModel>(HttpStatusCode statusCode, TModel responseModel)
      {
         var responseBody = JsonConvert.SerializeObject(responseModel);
         SetupResponse(statusCode, responseBody);
      }
   }

   public abstract class OwnUnitTestBase<TSUT> : OwnUnitTestBase
   {
      protected Func<TSUT> SUT => () => Container.GetInstance<TSUT>();
   }
}