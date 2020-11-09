using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Abstractions.Domain.Objects;

namespace IntraOffice.Nuget.HttpClient.Interfaces
{
   /// <summary>
   ///    This represents a handy decorator service to send 'GET' http requests
   /// </summary>
   public interface IHttpGetService
   {
      Task<TObject> GetObject<TObject>(string url, Dictionary<string, string> httpHeaders = null);

      Task<OwnFile> GetFile(string url, Dictionary<string, string> httpHeaders = null);
   }
}