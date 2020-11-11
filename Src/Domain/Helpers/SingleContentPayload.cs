using System.Collections.Generic;
using System.Net.Http;

namespace Tch.RestClient.Domain.Helpers
{
   /// <summary>
   ///    This is handy help class which represents single mime-type http request
   /// </summary>
   internal class SingleContentPayload
   {
      #region ctor

      public SingleContentPayload()
      {
         HttpHeaders = new Dictionary<string, string>();
      }

      #endregion

      public Dictionary<string, string> HttpHeaders { get; set; }

      public HttpContent HttpContent { get; set; }
   }
}