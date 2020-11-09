using System.Collections.Generic;
using System.Net.Http;

namespace Tch.HttpClient.Domain.Helpers
{
   /// <summary>
   ///    This is handy help class which represents single mime-type http request
   /// </summary>
   internal class SingleContentHttpRequest
   {
      #region ctor

      public SingleContentHttpRequest()
      {
         HttpHeaders = new Dictionary<string, string>();
      }

      #endregion

      public Dictionary<string, string> HttpHeaders { get; set; }

      public HttpContent HttpContent { get; set; }
   }
}