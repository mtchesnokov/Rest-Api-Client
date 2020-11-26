using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.Interfaces
{
   /// <summary>
   ///    This interface represents service to create and send http requests to external service.
   ///    It abstracts away the underlying http infrastructure to improve readability
   ///    and testability of the client code above the stack
   /// </summary>
   public interface IRestClient
   {
      /// <summary>
      /// Send 'GET' request
      /// </summary>
      /// <param name="url">Service url</param>
      /// <param name="httpHeaders">Optional dictionary with http headers</param>
      /// <returns>View model of http response</returns>
      Task<ResponseVm> Get(string url, Dictionary<string, string> httpHeaders = null);

      /// <summary>
      /// Send 'GET' request and treat response as file
      /// </summary>
      /// <param name="url">Service url</param>
      /// <param name="httpHeaders">Optional dictionary with http headers</param>
      /// <returns>File returned in http response</returns>
      Task<OwnFile> GetFile(string url, Dictionary<string, string> httpHeaders = null);

      /// <summary>
      /// Send 'PUT' request
      /// </summary>
      /// <param name="url">Service url</param>
      /// <param name="httpHeaders">Optional dictionary with http headers</param>
      /// <returns>View model of http response</returns>
      Task<ResponseVm> Put(string url, Dictionary<string, string> httpHeaders = null);

      /// <summary>
      /// Send 'PUT' request
      /// </summary>
      /// <param name="url">Service url</param>
      /// <param name="jsonText">Data as json string to be sent</param>
      /// <param name="httpHeaders">Optional dictionary with http headers</param>
      /// <returns>View model of http response</returns>
      Task<ResponseVm> Put(string url, string jsonText, Dictionary<string, string> httpHeaders = null);

      /// <summary>
      /// Send 'PUT' request
      /// </summary>
      /// <param name="url">Service url</param>
      /// <param name="jsonText">Data as json string to be sent</param>
      /// <param name="files">One of more files that will be sent along embedded in http request</param>
      /// <param name="httpHeaders">Optional dictionary with http headers</param>
      /// <returns>View model of http response</returns>
      Task<ResponseVm> Put(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders = null);

      /// <summary>
      /// Send 'DELETE' request
      /// </summary>
      /// <param name="url">Service url</param>
      /// <param name="httpHeaders">Optional dictionary with http headers</param>
      /// <returns>View model of http response</returns>
      Task<ResponseVm> Delete(string url, Dictionary<string, string> httpHeaders = null);

      /// <summary>
      /// Send 'DELETE' request
      /// </summary>
      /// <param name="url">Service url</param>
      /// <param name="jsonText">Data as json string to be sent</param>
      /// <param name="httpHeaders">Optional dictionary with http headers</param>
      /// <returns>View model of http response</returns>
      Task<ResponseVm> Delete(string url, string jsonText, Dictionary<string, string> httpHeaders = null);

      /// <summary>
      /// Send 'PATCH' request
      /// </summary>
      /// <param name="url">Service url</param>
      /// <param name="httpHeaders">Optional dictionary with http headers</param>
      /// <returns>View model of http response</returns>
      Task<ResponseVm> Patch(string url, Dictionary<string, string> httpHeaders = null);

      /// <summary>
      /// Send 'PATCH' request
      /// </summary>
      /// <param name="url">Service url</param>
      /// <param name="jsonText">Data as json string to be sent</param>
      /// <param name="httpHeaders">Optional dictionary with http headers</param>
      /// <returns>View model of http response</returns>
      Task<ResponseVm> Patch(string url, string jsonText, Dictionary<string, string> httpHeaders = null);

      /// <summary>
      /// Send 'PATCH' request
      /// </summary>
      /// <param name="url">Service url</param>
      /// <param name="jsonText">Data as json string to be sent</param>
      /// <param name="files">One of more files that will be sent along embedded in http request</param>
      /// <param name="httpHeaders">Optional dictionary with http headers</param>
      /// <returns>View model of http response</returns>
      Task<ResponseVm> Patch(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders = null);

      /// <summary>
      /// Send 'POST' request
      /// </summary>
      /// <param name="url">Service url</param>
      /// <param name="httpHeaders">Optional dictionary with http headers</param>
      /// <returns>View model of http response</returns>
      Task<ResponseVm> Post(string url, Dictionary<string, string> httpHeaders = null);

      /// <summary>
      /// Send 'POST' request
      /// </summary>
      /// <param name="url">Service url</param>
      /// <param name="jsonText">Data as json string to be sent</param>
      /// <param name="httpHeaders">Optional dictionary with http headers</param>
      /// <returns>View model of http response</returns>
      Task<ResponseVm> Post(string url, string jsonText, Dictionary<string, string> httpHeaders = null);

      /// <summary>
      /// Send 'POST' request
      /// </summary>
      /// <param name="url">Service url</param>
      /// <param name="jsonText">Data as json string to be sent</param>
      /// <param name="files">One of more files that will be sent along embedded in http request</param>
      /// <param name="httpHeaders">Optional dictionary with http headers</param>
      /// <returns>View model of http response</returns>
      Task<ResponseVm> Post(string url, string jsonText, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders = null);
   }
}