﻿using System.Net.Http;
using System.Threading.Tasks;
using IntraOffice.Nuget.Abstractions.Domain.Objects;

namespace IntraOffice.Nuget.HttpClient.Services.Helpers
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