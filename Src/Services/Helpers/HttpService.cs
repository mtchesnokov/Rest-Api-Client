using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Helpers;
using Tch.RestClient.Domain.Objects;
using Tch.RestClient.Interfaces.Helpers;
using Tch.RestClient.Services.Extensions;

namespace Tch.RestClient.Services.Helpers
{
   internal class HttpService : IHttpService
   {
      private readonly ISendHttpService<SingleContentPayload> _sendHttpService4Singletype;
      private readonly ISendHttpService<MultiContentPayload> _sendHttpService4Multitype;

      #region ctor

      public HttpService() : this(new SendHttpService4SingleContent(), new SendHttpService4MultiContent())
      {
      }

      internal HttpService(ISendHttpService<SingleContentPayload> sendHttpService4Singletype, ISendHttpService<MultiContentPayload> sendHttpService4Multitype)
      {
         _sendHttpService4Singletype = sendHttpService4Singletype;
         _sendHttpService4Multitype = sendHttpService4Multitype;
      }

      #endregion

      public Task<HttpResponseMessage> SendRaw(HttpMethod httpMethod, string url, string jsonText, Dictionary<string, string> httpHeaders, RestClientOptions options)
      {
         SingleContentPayload payload = jsonText.ToSingleContentHttpRequest(httpHeaders);
         return _sendHttpService4Singletype.Send(httpMethod, url, payload, options);
      }

      public Task<ResponseVm> Send(HttpMethod httpMethod, string url, Dictionary<string, string> httpHeaders, RestClientOptions options)
      {
         return Send(httpMethod, url, null, httpHeaders, options);
      }

      public async Task<ResponseVm> Send(HttpMethod httpMethod, string url, string jsonText, Dictionary<string, string> httpHeaders, RestClientOptions options)
      {
         SingleContentPayload payload = jsonText.ToSingleContentHttpRequest(httpHeaders);
         HttpResponseMessage httpResponseMessage = await _sendHttpService4Singletype.Send(httpMethod, url, payload, options);
         ResponseVm responseVm = await httpResponseMessage.ToResponseVm();
         return responseVm;
      }

      public async Task<ResponseVm> Send(HttpMethod httpMethod, string url, string jsonText, IEnumerable<FileVm> files, Dictionary<string, string> httpHeaders, RestClientOptions options)
      {
         var jsonContent = jsonText.ToHttpContent();

         var list = new List<HttpContent> {jsonContent};

         foreach (var file in files)
         {
            list.Add(file.ToHttpContent());
         }

         var payload = new MultiContentPayload {HttpHeaders = httpHeaders, HttpContents = list};
         var httpResponseMessage = await _sendHttpService4Multitype.Send(httpMethod, url, payload, options);
         var responseVm = await httpResponseMessage.ToResponseVm();
         return responseVm;
      }
   }
}