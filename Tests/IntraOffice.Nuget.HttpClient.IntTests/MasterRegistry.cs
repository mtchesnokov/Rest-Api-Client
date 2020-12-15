using StructureMap;
using Tch.RestClient.Interfaces;

namespace Tch.RestClient.IntTests
{
   public class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         For<IRestClient>().Use<Services.RestClient>().SelectConstructor(() => new Services.RestClient(null));
      }
   }
}