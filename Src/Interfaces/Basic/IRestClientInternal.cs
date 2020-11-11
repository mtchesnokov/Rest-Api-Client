using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Interfaces.Basic
{
   /// <summary>
   ///    This interface represents service that facades http infra stuff from the calling code
   /// </summary>
   internal interface IRestClientInternal
   {
      Task<ResponseDto> Send(HttpMethod httpMethod, string url, Dictionary<string, string> httpHeaders = null, RestClientOptions restClientOptions = null);

      Task<ResponseDto> Send(HttpMethod httpMethod, string url, string jsonText, Dictionary<string, string> httpHeaders = null, RestClientOptions restClientOptions = null);

      Task<ResponseDto> Send(HttpMethod httpMethod, string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders, RestClientOptions restClientOptions = null);

      Task<HttpResponseMessage> SendRaw(HttpMethod httpMethod, string url, string jsonText = null, Dictionary<string, string> httpHeaders = null, RestClientOptions restClientOptions = null);
   }
}