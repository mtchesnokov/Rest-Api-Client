using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Helpers;
using Tch.HttpClient.Domain.Objects;
using Tch.HttpClient.Interfaces;
using Tch.HttpClient.Interfaces.Helpers1;
using Tch.HttpClient.Services.Helpers1;

namespace Tch.HttpClient.Services
{
   /// <summary>
   ///    Implementation of <see cref="IHttpPostService" />
   /// </summary>
   public class HttpPostService : IHttpPostService
   {
      private readonly IHttpService<MultiContentHttpRequest> _multiTypeHttpService;
      private readonly IHttpService<SingleContentHttpRequest> _singleTypeHttpService;

      #region ctor

      public HttpPostService(IContainer container)
      {
         _singleTypeHttpService = container.GetInstance<IHttpService<SingleContentHttpRequest>>();
         _multiTypeHttpService = container.GetInstance<IHttpService<MultiContentHttpRequest>>();
      }

      #endregion

      public Task<HttpResponseMessage> PostJson(string url, string jsonText, Dictionary<string, string> httpHeaders, HttpClientOptions httpClientOptions)
      {
         var request = jsonText.ToSingleContentHttpRequest(httpHeaders);
         return _singleTypeHttpService.Send(HttpMethod.Post, url, request, httpClientOptions);
      }

      public Task<HttpResponseMessage> PostJson(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders, HttpClientOptions httpClientOptions)
      {
         var jsonContent = jsonText.ToHttpContent();
         var list = new List<HttpContent> { jsonContent };
         var httpContents = files.Select(file => file.ToHttpContent());
         list.AddRange(httpContents);
         var request = new MultiContentHttpRequest { HttpHeaders = httpHeaders, HttpContents = list };
         return _multiTypeHttpService.Send(HttpMethod.Post, url, request, httpClientOptions);
      }
   }

   /// <summary>
   ///    Implementation of <see cref="IHttpPostService{TResponse}" />
   /// </summary>
   public class HttpPostService<TResponse> : IHttpPostService<TResponse>
   {
      private readonly IHttpPostService _innerService;
      private readonly IContainer _container;

      #region ctor

      public HttpPostService(IContainer container)
      {
         _container = container;
         _innerService = container.GetInstance<IHttpPostService>();
      }

      #endregion

      public async Task<TResponse> PostModel<TModel>(string url, TModel model, Dictionary<string, string> httpHeaders, HttpClientOptions httpClientOptions)
      {
         var jsonText = _container.GetInstance<IModelAdapter<TModel>>().ToJsonText(model);
         var response = await PostJson(url, jsonText, httpHeaders, httpClientOptions);
         return response;
      }

      public async Task<TResponse> PostModel<TModel>(string url, TModel model, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders, HttpClientOptions httpClientOptions)
      {
         var jsonText = _container.GetInstance<IModelAdapter<TModel>>().ToJsonText(model);
         var response = await PostJson(url, jsonText, files, httpHeaders, httpClientOptions);
         return response;
      }

      public async Task<TResponse> PostJson(string url, string jsonText, Dictionary<string, string> httpHeaders, HttpClientOptions httpClientOptions)
      {
         var httpResponseMessage = await _innerService.PostJson(url, jsonText, httpHeaders, httpClientOptions);
         var response = await _container.GetInstance<IHttpResponseMessageAdapter<TResponse>>().ToResponse(httpResponseMessage);
         return response;
      }

      public async Task<TResponse> PostJson(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders, HttpClientOptions httpClientOptions)
      {
         var httpResponseMessage = await _innerService.PostJson(url, jsonText, files, httpHeaders, httpClientOptions);
         var response = await _container.GetInstance<IHttpResponseMessageAdapter<TResponse>>().ToResponse(httpResponseMessage);
         return response;
      }
   }
}