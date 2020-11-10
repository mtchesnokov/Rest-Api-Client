using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces.Helpers;

namespace Tch.RestClient.Services.Extensions
{
   internal class OwnFileAdapter : IAdapterAsync<HttpResponseMessage, OwnFile>
   {
      public async Task<OwnFile> AdaptAsync(HttpResponseMessage httpResponseMessage)
      {
         var content = await httpResponseMessage.Content.ReadAsByteArrayAsync();

         return new OwnFile
         {
            Content = content,
            FileName = GetFileName(httpResponseMessage.Content),
            ContentType = GetContentType(httpResponseMessage.Content)
         };
      }

      public static string GetFileName(HttpContent binaryContent)
      {
         var fileName = binaryContent.Headers?.ContentDisposition?.FileName ?? string.Empty;
         fileName = fileName.Replace("\"", "");
         return fileName;
      }

      public static string GetContentType(HttpContent httpContent)
      {
         return httpContent.Headers.ContentType?.MediaType ?? "";
      }
   }
}