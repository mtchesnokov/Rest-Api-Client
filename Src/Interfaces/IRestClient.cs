using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Interfaces
{
   public interface IRestClient
   {
      Task<ResponseVm> Put(string url, Dictionary<string, string> httpHeaders = null);

      Task<ResponseVm> Put(string url, string jsonText, Dictionary<string, string> httpHeaders = null);

      Task<ResponseVm> Put(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders = null);
   }
}