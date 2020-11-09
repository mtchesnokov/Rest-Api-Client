using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IntraOffice.Nuget.HttpClient.Domain.Objects;
using IntraOffice.Nuget.HttpClient.Interfaces.Helpers;

namespace IntraOffice.Nuget.HttpClient.Services.Helpers
{
   internal class HttpResponseVmAdapter1 : IHttpResponseMessageAdapter<HttpResponseVm1>
   {
      public Task<HttpResponseVm1> Adapt(HttpResponseMessage httpResponseMessage)
      {
         var responseMessage = httpResponseMessage;

         var result = new HttpResponseVm1
         {
            StatusCode = responseMessage.StatusCode,
            Location = responseMessage.TryGetLocationHeaderValue()
         };

         return Task.FromResult(result);
      }
   }
}