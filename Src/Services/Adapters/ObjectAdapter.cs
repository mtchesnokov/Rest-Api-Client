using Newtonsoft.Json;
using Tch.RestClient.Interfaces.Helpers;

namespace Tch.RestClient.Services.Adapters
{
   internal class ObjectAdapter : IAdapterSync<object, string>
   {
      public string AdaptSync(object source)
      {
         return JsonConvert.SerializeObject(source);
      }
   }
}