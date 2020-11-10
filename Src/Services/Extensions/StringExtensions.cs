using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Tch.RestClient.Domain.Helpers;

namespace Tch.RestClient.Services.Extensions
{
   internal static class StringExtensions
   {
      public static HttpContent ToHttpContent(this string jsonText)
      {
         return new StringContent(jsonText, Encoding.UTF8, "application/json");
      }

      public static SingleContentHttpRequest ToSingleContentHttpRequest(this string jsonText, Dictionary<string, string> httpHeaders)
      {
         var httpRequest = new SingleContentHttpRequest();

         if (httpHeaders != null)
         {
            httpRequest.HttpHeaders = httpHeaders;
         }

         if (!string.IsNullOrEmpty(jsonText))
         {
            httpRequest.HttpContent = jsonText.ToHttpContent();
         }

         return httpRequest;
      }
   }
}