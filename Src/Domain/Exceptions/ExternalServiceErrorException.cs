using System;

namespace Tch.RestClient.Domain.Exceptions
{
   /// <summary>
   ///    This exception is thrown when external http service has returned unsuccessful (4**, 5**) code
   /// </summary>
   public class ExternalServiceErrorException : Exception
   {
      public string UsedHttpMethod { get; set; }

      public string ServiceUrl { get; set; }

      public string ReturnedStatusCode { get; set; }

      public string ReasonPhrase { get; set; }

      public ExternalServiceErrorException() : base("External Http service returned error code")
      {
      }
   }
}