using System.Net;

namespace IntraOffice.Nuget.HttpClient.Domain.Objects
{
   public class HttpResponseVm2
   {
      public HttpStatusCode StatusCode { get; set; }

      public string Location { get; set; }

      public string ResponseBody { get; set; }
   }
}