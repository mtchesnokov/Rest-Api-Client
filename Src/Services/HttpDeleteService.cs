using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.HttpClient.Interfaces;
using IntraOffice.Nuget.HttpClient.Interfaces.Helpers;
using StructureMap;

namespace IntraOffice.Nuget.HttpClient.Services
{
   public class HttpDeleteService<THttpResponse> : IHttpDeleteService<THttpResponse>
   {
      private readonly IHttpResponseMessageAdapter<THttpResponse> _adapter;
      private readonly IHttpDeleteServiceInternal _innerService;
      private readonly IContainer _container;

      #region ctor

      public HttpDeleteService(IContainer container)
      {
         _container = container;
         _innerService = container.GetInstance<IHttpDeleteServiceInternal>();
         _adapter = container.GetInstance<IHttpResponseMessageAdapter<THttpResponse>>();
      }

      #endregion

      public async Task<THttpResponse> DeleteModel<TObject>(string url, TObject model, Dictionary<string, string> httpHeaders) where TObject : class
      {
         var jsonSerializeService = _container.GetInstance<ICanStringSerializeObjectService<TObject>>();
         var jsonText = jsonSerializeService.Serialize(model);
         var result = await DeleteJson(url, jsonText, httpHeaders);
         return result;
      }

      public async Task<THttpResponse> DeleteJson(string url, string jsonText, Dictionary<string, string> httpHeaders)
      {
         var httpResponseMessage = await _innerService.DeleteJson(url, jsonText, httpHeaders);
         var result = await _adapter.Adapt(httpResponseMessage);
         return result;
      }
   }

   public interface ICanStringSerializeObjectService<T>
   {
      string Serialize<TObject>(TObject model) where TObject : class;
   }
}