using System.Linq;
using System.Net.Http;

namespace IntraOffice.Nuget.HttpClient.Services.Helpers
{
   internal static class HttpResponseMessageCredentials
   {
      public static string TryGetLocationHeaderValue(this HttpResponseMessage responseMessage)
      {
         var responseMessageHeaders = responseMessage.Headers;

         if (!responseMessageHeaders.Contains("Location"))
         {
            return string.Empty;
         }

         return responseMessageHeaders.GetValues("Location").FirstOrDefault();
      }
   }
}