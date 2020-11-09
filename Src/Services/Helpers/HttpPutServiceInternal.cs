using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IntraOffice.Nuget.Abstractions.Domain.Objects;
using IntraOffice.Nuget.HttpClient.Domain.Helpers;
using IntraOffice.Nuget.HttpClient.Interfaces.Helpers;
using IntraOffice.Nuget.HttpClient.Interfaces.Helpers1;
using IntraOffice.Nuget.HttpClient.Services.Helpers.OwnFileExtensions;
using IntraOffice.Nuget.HttpClient.Services.Helpers.StringExtensions;

namespace IntraOffice.Nuget.HttpClient.Services.Helpers
{
   /// <summary>
   ///    Implementation of <see cref="IHttpPutServiceInternal" />
   /// </summary>
   internal class HttpPutServiceInternal : IHttpPutServiceInternal
   {
      private readonly IHttpService<MultiContentHttpRequest> _multiTypeHttpService;
      private readonly IHttpService<SingleContentHttpRequest> _singleTypeHttpService;

      #region ctor

      public HttpPutServiceInternal(IHttpService<SingleContentHttpRequest> singleTypeHttpService, IHttpService<MultiContentHttpRequest> multiTypeHttpService)
      {
         _singleTypeHttpService = singleTypeHttpService ?? throw new ArgumentNullException(nameof(singleTypeHttpService));
         _multiTypeHttpService = multiTypeHttpService ?? throw new ArgumentNullException(nameof(multiTypeHttpService));
      }

      #endregion

      public async Task<HttpResponseMessage> PutJson(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         var request = jsonText.ToSingleContentHttpRequest(httpHeaders);
         return await _singleTypeHttpService.Send(HttpMethod.Put, url, request);
      }

      public Task<HttpResponseMessage> PutJson(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders)
      {
         var jsonContent = jsonText.ToHttpContent();

         var list = new List<HttpContent> {jsonContent};

         foreach (var file in files)
         {
            list.Add(file.ToHttpContent());
         }

         var request = new MultiContentHttpRequest {HttpHeaders = httpHeaders, HttpContents = list};
         return _multiTypeHttpService.Send(HttpMethod.Put, url, request);
      }
   }
}