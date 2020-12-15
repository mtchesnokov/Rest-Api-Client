using StructureMap;
using Tch.RestClient.Domain.Helpers;
using Tch.RestClient.Interfaces;
using Tch.RestClient.Interfaces.Helpers;
using Tch.RestClient.Services.Helpers;

namespace Tch.RestClient.UnitTests
{
   public class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         For<IRestClient>().Use<Services.RestClient>().SelectConstructor(() => new Services.RestClient(null, null));
         For<IHttpService>().Use<HttpService>().SelectConstructor(() => new HttpService(null, null));
         For<ISendHttpService<SingleContentPayload>>().Use<SendHttpService4SingleContent>().SelectConstructor(() => new SendHttpService4SingleContent(null));
         For<ISendHttpService<MultiContentPayload>>().Use<SendHttpService4MultiContent>().SelectConstructor(() => new SendHttpService4MultiContent(null));
         //For<IHttpService>().Use<FakeHttpService>();
      }
   }
}