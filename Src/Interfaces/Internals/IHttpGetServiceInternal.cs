using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tch.HttpClient.Interfaces.Internals
{
   internal interface IHttpGetServiceInternal
   {
      Task<HttpResponseMessage> Get(string url, Dictionary<string, string> httpHeaders = null);
   }
}