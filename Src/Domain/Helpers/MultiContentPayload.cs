using System.Collections.Generic;
using System.Net.Http;

namespace Tch.RestClient.Domain.Helpers
{
   /// <summary>
   ///    This is handy help class which represents multiple mime-types http request
   /// </summary>
   internal class MultiContentPayload
   {
      #region ctor

      public MultiContentPayload()
      {
         HttpHeaders = new Dictionary<string, string>();
         HttpContents = new HttpContent[0];
      }

      #endregion

      public Dictionary<string, string> HttpHeaders { get; set; }

      public IEnumerable<HttpContent> HttpContents { get; set; }
   }
}