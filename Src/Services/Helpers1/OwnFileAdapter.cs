using System.Net.Http;
using System.Threading.Tasks;

namespace Tch.HttpClient.Services.Helpers1
{
   internal class OwnFileAdapter : IHttpResponseMessageAdapter<OwnFile>
   {
      public async Task<OwnFile> Adapt(HttpResponseMessage httpResponseMessage)
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