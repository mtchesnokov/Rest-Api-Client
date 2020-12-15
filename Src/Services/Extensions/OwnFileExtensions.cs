using System.Net.Http;
using System.Net.Http.Headers;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Services.Extensions
{
   internal static class OwnFileExtensions
   {
      public static HttpContent ToHttpContent(this FileVm fileVm)
      {
         var binaryContent = new ByteArrayContent(fileVm.Content);

         if (!string.IsNullOrEmpty(fileVm.ContentType))
         {
            binaryContent.Headers.ContentType = new MediaTypeHeaderValue(fileVm.ContentType);
         }

         if (!string.IsNullOrEmpty(fileVm.FileName))
         {
            binaryContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = fileVm.FileName };
         }

         return binaryContent;
      }
   }
}