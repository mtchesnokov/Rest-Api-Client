using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Exceptions;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces;
using Tch.RestClient.Interfaces.Basic;
using Tch.RestClient.Services.Basic;
using Tch.RestClient.Services.Extensions;

namespace Tch.RestClient.Services
{
   public class RestClient : IRestClient
   {
      private readonly IRestClientInternal _innerService;
      private readonly RestClientOptions _options;

      #region ctor

      public RestClient(RestClientOptions options = null) : this(new RestClientInternal(), options)
      {
      }

      internal RestClient(IRestClientInternal innerService, RestClientOptions options)
      {
         _options = options;
         _innerService = innerService;
      }

      #endregion

      public Task<ResponseDto> Put(string url, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(HttpMethod.Put, url, httpHeaders, _options);
      }

      public Task<ResponseDto> Put(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(HttpMethod.Put, url, jsonText, httpHeaders, _options);
      }

      public Task<ResponseDto> Put(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(HttpMethod.Put, url, jsonText, files, httpHeaders, _options);
      }

      public Task<ResponseDto> Patch(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(new HttpMethod("PATCH"), url, jsonText, files, httpHeaders, _options);
      }

      public Task<ResponseDto> Patch(string url, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(new HttpMethod("PATCH"), url, httpHeaders, _options);
      }

      public Task<ResponseDto> Patch(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(new HttpMethod("PATCH"), url, jsonText, httpHeaders, _options);
      }

      public Task<ResponseDto> Delete(string url, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(HttpMethod.Delete, url, httpHeaders, _options);
      }

      public Task<ResponseDto> Delete(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(HttpMethod.Put, url, jsonText, httpHeaders, _options);
      }

      public Task<ResponseDto> Post(string url, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(HttpMethod.Post, url, httpHeaders, _options);
      }

      public Task<ResponseDto> Post(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(HttpMethod.Post, url, jsonText, httpHeaders, _options);
      }

      public Task<ResponseDto> Post(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(HttpMethod.Post, url, jsonText, files, httpHeaders, _options);
      }

      public Task<ResponseDto> Get(string url, Dictionary<string, string> httpHeaders)
      {
         return _innerService.Send(HttpMethod.Get, url, httpHeaders, _options);
      }

      public async Task<OwnFile> GetFile(string url, Dictionary<string, string> httpHeaders = null)
      {
         var httpResponseMessage = await _innerService.SendRaw(HttpMethod.Get, url, null, httpHeaders, _options);

         if (!httpResponseMessage.IsSuccessStatusCode)
         {
            throw new ExternalServiceHttpException
            {
               ReturnedStatusCode = httpResponseMessage.StatusCode.ToString(),
               ReasonPhrase = httpResponseMessage.ReasonPhrase,
               ServiceUrl = url,
               UsedHttpMethod = "GET"
            };
         }

         var result = await httpResponseMessage.ReadFile();
         return result;
      }
   }
}