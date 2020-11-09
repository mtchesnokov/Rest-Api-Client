﻿using IntraOffice.Nuget.HttpClient.Domain.Exceptions;
using IntraOffice.Nuget.HttpClient.Interfaces;
using IntraOffice.Nuget.HttpClient.IntTests.TestExtensions;
using IntraOffice.Nuget.Testing.Abstractions.Helpers;
using IntraOffice.Nuget.Testing.Abstractions;
using NUnit.Framework;

namespace IntraOffice.Nuget.HttpClient.IntTests.UseCases.Automatic.HttpGetService.Test14Controller
{
   [Category("EndToEnd")]
   [Explicit]
   public class UnhappyTests : IntegrationTestBase<IHttpGetService>
   {
      [Test]
      [TestCase("/test15")]
      public void BadRequest_Returned(string relativeUrl)
      {
         //arrange
         var url = this.GetUrl(relativeUrl);

         //assert
         MyAssert.ThrowsAsync<ExternalServiceHttpException>(() => SUT().GetFile(url));
      }
   }
}