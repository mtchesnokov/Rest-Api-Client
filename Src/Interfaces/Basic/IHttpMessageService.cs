﻿using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Interfaces.Basic
{
   /// <summary>
   ///    This interface represents low level service to make requests
   /// </summary>
   internal interface IHttpMessageService
   {
      Task<HttpResponseMessage> Send(HttpRequestMessage httpRequestMessage, HttpClientOptions httpClientOptions);
   }
}