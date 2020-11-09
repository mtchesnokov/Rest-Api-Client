using System.Collections.Generic;
using System.Net.Http;

namespace Tch.HttpClient.Services.Helpers1
{
   public static class HttpRequestMessageExtensions
   {
      public static void AddHttpHeaders(this HttpRequestMessage httpRequestMessage, Dictionary<string, string> httpHeaders)
      {
         if (httpHeaders != null)
         {
            foreach (var httpHeader in httpHeaders)
            {
               httpRequestMessage.Headers.Add(httpHeader.Key, httpHeader.Value);
            }
         }
      }
   }
}