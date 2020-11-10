using System.Net;

namespace Tch.RestClient.Domain.Objects
{
   public class ResponseVm
   {
      public HttpStatusCode StatusCode { get; set; }

      public string ReasonPhrase { get; set; }

      public string ResponseBody { get; set; }
   }
}