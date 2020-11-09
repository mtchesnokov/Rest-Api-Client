using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.HttpClient.Interfaces;
using IntraOffice.Nuget.HttpClient.Interfaces.Helpers;
using StructureMap;

namespace IntraOffice.Nuget.HttpClient.Services
{
   /// <summary>
   ///    Implementation of <see cref="IHttpPatchService{THttpResponse}" />
   /// </summary>
   public class HttpPatchService<THttpResponse> : IHttpPatchService<THttpResponse>
   {
      private readonly IHttpPatchServiceInternal _innerService;
      private readonly IHttpResponseMessageAdapter<THttpResponse> _adapter;
      private readonly IContainer _container;

      #region ctor

      public HttpPatchService(IContainer container)
      {
         _innerService = container.GetInstance<IHttpPatchServiceInternal>();
         _adapter = container.GetInstance<IHttpResponseMessageAdapter<THttpResponse>>();
         _container = container;
      }

      #endregion

      public async Task<THttpResponse> PatchModel<TModel>(string url, TModel model, Dictionary<string, string> httpHeaders = null)
      {
         var modelSerializeService = _container.GetInstance<ICanStringSerializeObjectService<TModel>>();
         var jsonText = modelSerializeService.Serialize(model);
         var result = await PatchJson(url, jsonText, httpHeaders);
         return result;
      }

      public async Task<THttpResponse> PatchJson(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         var httpResponseMessage = await _innerService.PatchJson(url, jsonText, httpHeaders);
         var result = await _adapter.Adapt(httpResponseMessage);
         return result;
      }
   }
}