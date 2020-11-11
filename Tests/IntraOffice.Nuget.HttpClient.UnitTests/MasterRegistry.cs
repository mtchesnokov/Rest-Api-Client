using StructureMap;
using Tch.RestClient.Domain.Helpers;
using Tch.RestClient.Interfaces;
using Tch.RestClient.Interfaces.Basic;
using Tch.RestClient.Services.Basic;
using Tch.RestClient.UnitTests.Fakes;

namespace Tch.RestClient.UnitTests
{
   public class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         For<IRestClient>().Use<Services.RestClient>().SelectConstructor(() => new Services.RestClient(null, null));
         For<IRestClientInternal>().Use<RestClientInternal>().SelectConstructor(() => new RestClientInternal(null, null));
         For<IHttpPayloadService<SingleContentPayload>>().Use<HttpPayloadService4SingleContentPayload>().SelectConstructor(() => new HttpPayloadService4SingleContentPayload(null));
         For<IHttpPayloadService<MultiContentPayload>>().Use<HttpPayloadService4MultiContentPayload>().SelectConstructor(() => new HttpPayloadService4MultiContentPayload(null));
         //For<IHttpService>().Use<FakeHttpService>();
      }
   }
}