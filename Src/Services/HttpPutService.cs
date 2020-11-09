using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tch.HttpClient.Services
{
   public class HttpPutService<THttpResponse> : IHttpPutService
   {
      private readonly IHttpPutServiceInternal _innerService;
      private readonly IHttpResponseMessageAdapter<THttpResponse> _adapter;
      private readonly IContainer _container;

      #region ctor

      public HttpPutService(IContainer container)
      {
         _innerService = container.GetInstance<IHttpPutServiceInternal>();
         _adapter = container.GetInstance<IHttpResponseMessageAdapter<THttpResponse>>();
         _container = container;
      }

      #endregion

      public async Task<THttpResponse> PutModel<TModel>(string url, TModel model, Dictionary<string, string> httpHeaders = null)
      {
         var modelSerializeService = _container.GetInstance<ICanStringSerializeObjectService<TModel>>();
         var jsonText = modelSerializeService.Serialize(model);
         var result = await PutJson(url, jsonText, httpHeaders);
         return result;
      }


      public async Task<THttpResponse> PutJson(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         var httpResponseMessage = await _innerService.PutJson(url, jsonText, httpHeaders);
         var result = await _adapter.Adapt(httpResponseMessage);
         return result;
      }
   }
}