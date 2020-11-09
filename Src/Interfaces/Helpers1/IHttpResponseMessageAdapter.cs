using System.Net.Http;
using System.Threading.Tasks;

namespace Tch.HttpClient.Interfaces.Helpers1
{
   internal interface IHttpResponseMessageAdapter<TDestination>
   {
      Task<TDestination> ToResponse(HttpResponseMessage httpResponseMessage);
   }
}