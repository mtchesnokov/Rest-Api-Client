using System;
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
      private readonly IHttpService _innerService;
      private readonly RestClientOptions _options;

      #region ctor

      public RestClient(RestClientOptions options = null) : this(new HttpService(), options)
      {
      }

      internal RestClient(IHttpService innerService, RestClientOptions options)
      {
         _options = options;
         _innerService = innerService;
      }

      #endregion

      public Task<ResponseVm> Put(string url, Dictionary<string, string> httpHeaders)
      {
         if (string.IsNullOrEmpty(url))
         {
            throw new ArgumentNullException(nameof(url));
         }

         return _innerService.Send(HttpMethod.Put, url, httpHeaders, _options);
      }

      public Task<ResponseVm> Put(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         if (string.IsNullOrEmpty(url))
         {
            throw new ArgumentNullException(nameof(url));
         }

         if (string.IsNullOrEmpty(jsonText))
         {
            throw new ArgumentNullException(nameof(url));
         }

         return _innerService.Send(HttpMethod.Put, url, jsonText, httpHeaders, _options);
      }

      public Task<ResponseVm> Put(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders)
      {
         if (string.IsNullOrEmpty(url))
         {
            throw new ArgumentNullException(nameof(url));
         }

         if (string.IsNullOrEmpty(jsonText))
         {
            throw new ArgumentNullException(nameof(url));
         }

         return _innerService.Send(HttpMethod.Put, url, jsonText, files, httpHeaders, _options);
      }

      public Task<ResponseVm> Patch(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders)
      {
         if (string.IsNullOrEmpty(url))
         {
            throw new ArgumentNullException(nameof(url));
         }

         if (string.IsNullOrEmpty(jsonText))
         {
            throw new ArgumentNullException(nameof(url));
         }

         return _innerService.Send(new HttpMethod("PATCH"), url, jsonText, files, httpHeaders, _options);
      }

      public Task<ResponseVm> Patch(string url, Dictionary<string, string> httpHeaders)
      {
         if (string.IsNullOrEmpty(url))
         {
            throw new ArgumentNullException(nameof(url));
         }

         return _innerService.Send(new HttpMethod("PATCH"), url, httpHeaders, _options);
      }

      public Task<ResponseVm> Patch(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         if (string.IsNullOrEmpty(url))
         {
            throw new ArgumentNullException(nameof(url));
         }

         if (string.IsNullOrEmpty(jsonText))
         {
            throw new ArgumentNullException(nameof(url));
         }

         return _innerService.Send(new HttpMethod("PATCH"), url, jsonText, httpHeaders, _options);
      }

      public Task<ResponseVm> Delete(string url, Dictionary<string, string> httpHeaders)
      {
         if (string.IsNullOrEmpty(url))
         {
            throw new ArgumentNullException(nameof(url));
         }

         return _innerService.Send(HttpMethod.Delete, url, httpHeaders, _options);
      }

      public Task<ResponseVm> Delete(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         if (string.IsNullOrEmpty(url))
         {
            throw new ArgumentNullException(nameof(url));
         }

         if (string.IsNullOrEmpty(jsonText))
         {
            throw new ArgumentNullException(nameof(url));
         }

         return _innerService.Send(HttpMethod.Put, url, jsonText, httpHeaders, _options);
      }

      public Task<ResponseVm> Post(string url, Dictionary<string, string> httpHeaders)
      {
         if (string.IsNullOrEmpty(url))
         {
            throw new ArgumentNullException(nameof(url));
         }

         return _innerService.Send(HttpMethod.Post, url, httpHeaders, _options);
      }

      public Task<ResponseVm> Post(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         if (string.IsNullOrEmpty(url))
         {
            throw new ArgumentNullException(nameof(url));
         }

         if (string.IsNullOrEmpty(jsonText))
         {
            throw new ArgumentNullException(nameof(url));
         }

         return _innerService.Send(HttpMethod.Post, url, jsonText, httpHeaders, _options);
      }

      public Task<ResponseVm> Post(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders)
      {
         if (string.IsNullOrEmpty(url))
         {
            throw new ArgumentNullException(nameof(url));
         }

         if (string.IsNullOrEmpty(jsonText))
         {
            throw new ArgumentNullException(nameof(url));
         }

         return _innerService.Send(HttpMethod.Post, url, jsonText, files, httpHeaders, _options);
      }

      public Task<ResponseVm> Get(string url, Dictionary<string, string> httpHeaders)
      {
         if (string.IsNullOrEmpty(url))
         {
            throw new ArgumentNullException(nameof(url));
         }

         return _innerService.Send(HttpMethod.Get, url, httpHeaders, _options);
      }

      public async Task<OwnFile> GetFile(string url, Dictionary<string, string> httpHeaders = null)
      {
         if (string.IsNullOrEmpty(url))
         {
            throw new ArgumentNullException(nameof(url));
         }

         var httpResponseMessage = await _innerService.SendRaw(HttpMethod.Get, url, null, httpHeaders, _options);

         if (!httpResponseMessage.IsSuccessStatusCode)
         {
            throw new ExternalServiceErrorException
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