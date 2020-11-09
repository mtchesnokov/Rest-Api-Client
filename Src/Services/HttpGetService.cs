using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.HttpClient.Domain.Objects;
using Tch.HttpClient.Interfaces;
using Tch.HttpClient.Interfaces.Helpers;
using Tch.HttpClient.Services.Helpers;

namespace Tch.HttpClient.Services
{
   public class HttpGetService : IHttpGetService
   {
      private readonly IHttpGetServiceInternal _innerService;

      #region ctor

      public HttpGetService() : this(new HttpGetServiceInternal())
      {
      }

      internal HttpGetService(IHttpGetServiceInternal innerService)
      {
         _innerService = innerService;
      }

      #endregion

      public async Task<TObject> GetObject<TObject>(string url, Dictionary<string, string> httpHeaders)
      {
         var httpResponseMessage = await _innerService.Get(url, httpHeaders);


         var adapter = _container.GetInstance<IHttpResponseMessageAdapter<TObject>>();
         var result = await adapter.Adapt(httpResponseMessage);
         return result;
      }

      public async Task<OwnFile> GetFile(string url, Dictionary<string, string> httpHeaders = null)
      {
         var httpResponseMessage = await _innerService.Get(url, httpHeaders);
         var adapter = _container.GetInstance<IHttpResponseMessageAdapter<OwnFile>>();
         var result = await adapter.Adapt(httpResponseMessage);
         return result;
      }
   }
}