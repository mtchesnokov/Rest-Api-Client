using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tch.HttpClient.Interfaces.Helpers
{
   internal interface IHttpPatchServiceInternal
   {
      Task<HttpResponseMessage> Patch(string url, string jsonText = null, Dictionary<string, string> httpHeaders = null);
   }
}