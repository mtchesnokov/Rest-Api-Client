using System.Collections.Generic;
using System.Net.Http;

namespace Tch.HttpClient.Domain.Helpers
{
   /// <summary>
   ///    This is handy help class which represents multiple mime-types http request
   /// </summary>
   internal class MultiContentHttpRequest
   {
      #region ctor

      public MultiContentHttpRequest()
      {
         HttpHeaders = new Dictionary<string, string>();
         HttpContents = new HttpContent[0];
      }

      #endregion

      public Dictionary<string, string> HttpHeaders { get; set; }

      public IEnumerable<HttpContent> HttpContents { get; set; }
   }
}