using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Abstractions.Domain.Objects;
using IntraOffice.Nuget.HttpClient.Interfaces;
using IntraOffice.Nuget.HttpClient.Interfaces.Helpers;
using StructureMap;

namespace IntraOffice.Nuget.HttpClient.Services
{
   /// <summary>
   ///    Implementation of <see cref="IHttpGetService" />
   /// </summary>
   public class HttpGetService : IHttpGetService
   {
      private readonly IHttpGetServiceInternal _innerService;
      private readonly IContainer _container;

      #region ctor

      public HttpGetService(IContainer container)
      {
         _innerService = container.GetInstance<IHttpGetServiceInternal>();
         _container = container;
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