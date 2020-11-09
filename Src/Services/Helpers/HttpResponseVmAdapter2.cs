using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IntraOffice.Nuget.HttpClient.Domain.Objects;
using IntraOffice.Nuget.HttpClient.Interfaces.Helpers;

namespace IntraOffice.Nuget.HttpClient.Services.Helpers
{
   internal class HttpResponseVmAdapter2 : IHttpResponseMessageAdapter<HttpResponseVm2>
   {
      public async Task<HttpResponseVm2> Adapt(HttpResponseMessage httpResponseMessage)
      {
         var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

         var result = new HttpResponseVm2
         {
            StatusCode = httpResponseMessage.StatusCode,
            Location = httpResponseMessage.TryGetLocationHeaderValue(),
            ResponseBody = responseBody
         };

         return result;
      }
   }
}