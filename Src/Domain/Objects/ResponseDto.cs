using System.Net;

namespace Tch.RestClient.Domain.Objects
{
   public class ResponseDto
   {
      public HttpStatusCode StatusCode { get; set; }

      public string ReasonPhrase { get; set; }

      public string ResponseBody { get; set; }

      public bool IsSuccessStatusCode { get; set; }
   }
}