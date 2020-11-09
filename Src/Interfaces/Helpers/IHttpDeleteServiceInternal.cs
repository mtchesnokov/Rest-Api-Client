using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tch.HttpClient.Interfaces.Helpers
{
   internal interface IHttpDeleteServiceInternal
   {
      Task<HttpResponseMessage> Delete(string url, string jsonText = null, Dictionary<string, string> httpHeaders = null);
   }
}