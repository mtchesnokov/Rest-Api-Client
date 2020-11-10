using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Services.Extensions
{
   internal static class HttpResponseMessageExtensions
   {
      public static async Task<ResponseVm> ToResponseVm(this HttpResponseMessage httpResponseMessage)
      {
         var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

         return new ResponseVm
         {
            StatusCode = httpResponseMessage.StatusCode,
            ReasonPhrase = httpResponseMessage.ReasonPhrase,
            ResponseBody = responseBody
         };
      }
   }
}