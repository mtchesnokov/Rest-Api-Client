using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Helpers;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces.Basic;
using Tch.RestClient.Services.Extensions;

namespace Tch.RestClient.Services.Basic
{
   internal class RestClientInternal : IRestClientInternal
   {
      private readonly IHttpPayloadService<SingleContentPayload> _singleTypeHttpService;
      private readonly IHttpPayloadService<MultiContentPayload> _multiTypeHttpService;

      #region ctor

      public RestClientInternal() : this(new HttpPayloadService4SingleContentPayload(), new HttpPayloadService4MultiContentPayload())
      {
      }

      internal RestClientInternal(IHttpPayloadService<SingleContentPayload> singleTypeHttpService, IHttpPayloadService<MultiContentPayload> multiTypeHttpService)
      {
         _singleTypeHttpService = singleTypeHttpService;
         _multiTypeHttpService = multiTypeHttpService;
      }

      #endregion

      public Task<HttpResponseMessage> SendRaw(HttpMethod httpMethod, string url, string jsonText, Dictionary<string, string> httpHeaders, RestClientOptions restClientOptions)
      {
         var request = jsonText.ToSingleContentHttpRequest(httpHeaders);
         return _singleTypeHttpService.Send(httpMethod, url, request, restClientOptions);
      }

      public Task<ResponseDto> Send(HttpMethod httpMethod, string url, Dictionary<string, string> httpHeaders, RestClientOptions restClientOptions)
      {
         return Send(httpMethod, url, null, httpHeaders, restClientOptions);
      }

      public async Task<ResponseDto> Send(HttpMethod httpMethod, string url, string jsonText, Dictionary<string, string> httpHeaders, RestClientOptions restClientOptions)
      {
         var request = jsonText.ToSingleContentHttpRequest(httpHeaders);
         var response = await _singleTypeHttpService.Send(httpMethod, url, request, restClientOptions);
         var result = await response.ToResponseVm();
         return result;
      }

      public async Task<ResponseDto> Send(HttpMethod httpMethod, string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders, RestClientOptions restClientOptions)
      {
         var jsonContent = jsonText.ToHttpContent();

         var list = new List<HttpContent> {jsonContent};

         foreach (var file in files)
         {
            list.Add(file.ToHttpContent());
         }

         var request = new MultiContentPayload {HttpHeaders = httpHeaders, HttpContents = list};
         var response = await _multiTypeHttpService.Send(httpMethod, url, request, restClientOptions);
         var result = await response.ToResponseVm();
         return result;
      }
   }
}