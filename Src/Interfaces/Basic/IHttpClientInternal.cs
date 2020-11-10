using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Interfaces.Basic
{
   internal interface IHttpClientInternal
   {
      Task<ResponseVm> Send(HttpMethod httpMethod, string url, Dictionary<string, string> httpHeaders = null);

      Task<ResponseVm> Send(HttpMethod httpMethod, string url, string jsonText, Dictionary<string, string> httpHeaders = null);

      Task<ResponseVm> Send(HttpMethod httpMethod, string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders);
   }
}