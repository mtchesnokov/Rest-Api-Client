using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Services.Extensions
{
   internal static class HttpResponseMessageExtensions
   {
      public static async Task<ResponseDto> ToResponseVm(this HttpResponseMessage httpResponseMessage)
      {
         var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

         return new ResponseDto
         {
            StatusCode = httpResponseMessage.StatusCode,
            ReasonPhrase = httpResponseMessage.ReasonPhrase,
            ResponseBody = responseBody,
            IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode
         };
      }

      public static async Task<OwnFile> ReadFile(this HttpResponseMessage httpResponseMessage)
      {
         var content = await httpResponseMessage.Content.ReadAsByteArrayAsync();

         return new OwnFile
         {
            Content = content,
            FileName = GetFileName(httpResponseMessage.Content),
            ContentType = GetContentType(httpResponseMessage.Content)
         };
      }

      private static string GetFileName(HttpContent binaryContent)
      {
         var fileName = binaryContent.Headers?.ContentDisposition?.FileName ?? string.Empty;
         fileName = fileName.Replace("\"", "");
         return fileName;
      }

      private static string GetContentType(HttpContent httpContent)
      {
         return httpContent.Headers.ContentType?.MediaType ?? "";
      }
   }
}