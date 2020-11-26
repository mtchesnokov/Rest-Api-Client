﻿using System;
using System.Net;
using NUnit.Framework;
using Tch.RestClient.Domain.Exceptions;
using Tch.RestClient.Interfaces;
using Tch.RestClient.UnitTests.TestExtensions;

namespace Tch.RestClient.UnitTests.UseCases.Get
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
         var exception = Assert.ThrowsAsync<ArgumentNullException>(() => SUT().Get(url));

         //print
         exception.Print();
      }

      [Test]
      public void Server_Offline()
      {
         //arrange
         var url = "http://someurl";
         this.SetupResponse(HttpStatusCode.ServiceUnavailable, "ServiceOffline");

         //assert
         var exception = Assert.ThrowsAsync<ExternalServiceOfflineException>(() => SUT().Get(url));

         //print
         exception.Print();
      }
   }
}