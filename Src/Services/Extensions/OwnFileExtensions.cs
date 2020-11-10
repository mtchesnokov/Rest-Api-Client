using System.Net.Http;
using System.Net.Http.Headers;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Services.Extensions
{
   internal static class OwnFileExtensions
   {
      public static HttpContent ToHttpContent(this OwnFile file)
      {
         var binaryContent = new ByteArrayContent(file.Content);

         if (!string.IsNullOrEmpty(file.ContentType))
         {
            binaryContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
         }

         if (!string.IsNullOrEmpty(file.FileName))
         {
            binaryContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = file.FileName };
         }

         return binaryContent;
      }
   }
}