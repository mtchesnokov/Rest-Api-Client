using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tch.HttpClient.Interfaces.Helpers1;

namespace Tch.HttpClient.Services.Helpers1
{
   internal class ObjectAdapter<TObject> : IHttpResponseMessageAdapter<TObject>
   {
      public async Task<TObject> ToResponse(HttpResponseMessage httpResponseMessage)
      {
         var responseBodyText = await httpResponseMessage.Content.ReadAsStringAsync();
         var result = JsonConvert.DeserializeObject<TObject>(responseBodyText);
         return result;
      }
   }
}