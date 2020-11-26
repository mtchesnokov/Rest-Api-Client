using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Interfaces.Basic
{
   /// <summary>
   ///    This interface represents service that decides which payload type to use, build request, and send it
   /// </summary>
   internal interface IHttpService
   {
      Task<ResponseVm> Send(HttpMethod httpMethod, string url, Dictionary<string, string> httpHeaders = null, RestClientOptions options = null);

      Task<ResponseVm> Send(HttpMethod httpMethod, string url, string jsonText, Dictionary<string, string> httpHeaders = null, RestClientOptions options = null);

      Task<ResponseVm> Send(HttpMethod httpMethod, string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders, RestClientOptions options = null);

      Task<HttpResponseMessage> SendRaw(HttpMethod httpMethod, string url, string jsonText = null, Dictionary<string, string> httpHeaders = null, RestClientOptions options = null);
   }
}