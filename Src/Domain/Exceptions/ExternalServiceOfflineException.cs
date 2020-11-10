using System;

namespace Tch.RestClient.Domain.Exceptions
{
   /// <summary>
   ///    This exception is thrown when external http service has returned 502 (bad gateway)
   /// </summary>
   public class ExternalServiceOfflineException : Exception
   {
      public string HttpMethod { get; set; }

      public string ServiceUrl { get; set; }

      public string ReasonPhrase { get; set; }

      public string ResponseStatusCode { get; set; }

      public ExternalServiceOfflineException() : base("External Http service is offline")
      {
      }
   }
}