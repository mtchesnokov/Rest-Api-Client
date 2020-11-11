using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Interfaces
{
   public interface IRestClient
   {
      Task<ResponseDto> Put(string url, Dictionary<string, string> httpHeaders = null);

      Task<ResponseDto> Put(string url, string jsonText, Dictionary<string, string> httpHeaders = null);

      Task<ResponseDto> Put(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders = null);

      Task<ResponseDto> Delete(string url, Dictionary<string, string> httpHeaders);

      Task<ResponseDto> Delete(string url, string jsonText, Dictionary<string, string> httpHeaders);

      Task<ResponseDto> Patch(string url, Dictionary<string, string> httpHeaders);

      Task<ResponseDto> Patch(string url, string jsonText, Dictionary<string, string> httpHeaders);

      Task<ResponseDto> Patch(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders);

      Task<ResponseDto> Post(string url, Dictionary<string, string> httpHeaders);

      Task<ResponseDto> Post(string url, string jsonText, Dictionary<string, string> httpHeaders);

      Task<ResponseDto> Post(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders);
      
      Task<ResponseDto> Get(string url, Dictionary<string, string> httpHeaders = null);

      Task<OwnFile> GetFile(string url, Dictionary<string, string> httpHeaders = null);
   }
}