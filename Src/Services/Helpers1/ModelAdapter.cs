using Newtonsoft.Json;
using Tch.HttpClient.Interfaces.Helpers;

namespace Tch.HttpClient.Services.Helpers1
{
   internal class ModelAdapter<TModel> : IModelAdapter<TModel>
   {
      public string ToJsonText(TModel source)
      {
         return JsonConvert.SerializeObject(source);
      }
   }
}