using System.Net;

namespace IntraOffice.Nuget.HttpClient.Domain.Objects
{
   public class HttpResponseVm1
   {
      public HttpStatusCode StatusCode { get; set; }

      public string Location { get; set; }
   }
}