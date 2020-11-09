using Tch.HttpClient.Domain.Helpers;
using Tch.HttpClient.Interfaces;
using Tch.HttpClient.Interfaces.Helpers1;
using Tch.HttpClient.Services;
using Tch.HttpClient.Services.Helpers1;

namespace Tch.HttpClient
{
   public class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         For<IOwnAppLogService>().Use<OwnAppLogService>();
         For(typeof(IModelAdapter<>)).Use(typeof(ModelAdapter<>));
         For(typeof(IHttpResponseMessageAdapter<>)).Use(typeof(ObjectAdapter<>));

         For<IHttpMessageService>().Use<HttpMessageService>();
         For<IHttpService<SingleContentHttpRequest>>().Use<HttpService4SingleContentRequests>();
         For<IHttpService<MultiContentHttpRequest>>().Use<HttpService4MultiContentRequests>();

         For<IHttpPostService>().Use<HttpPostService>();
         For(typeof(IHttpPostService<>)).Use(typeof(HttpPostService<>));

         //For<IHttpResponseMessageAdapter<OwnFile>>().Use<OwnFileAdapter>();
         //For<IHttpResponseMessageAdapter<HttpResponseVm1>>().Use<HttpResponseVmAdapter1>();
         //For<IHttpResponseMessageAdapter<HttpResponseVm2>>().Use<HttpResponseVmAdapter2>();

         //For<IHttpGetServiceInternal>().Use<HttpGetServiceInternal>();
         //For<IHttpDeleteServiceInternal>().Use<HttpDeleteServiceInternal>();
         //For<IHttpPatchServiceInternal>().Use<HttpPatchServiceInternal>();
         //For<IHttpPutServiceInternal>().Use<HttpPutServiceInternal>();

         //For<IHttpGetService>().Use<HttpGetService>();

         //For(typeof(IHttpDeleteService<>)).Use(typeof(HttpDeleteService<>));
         //For(typeof(IHttpPatchService<>)).Use(typeof(HttpPatchService<>));
         //For(typeof(IHttpPutService<>)).Use(typeof(HttpPutService<>));
      }
   }
}