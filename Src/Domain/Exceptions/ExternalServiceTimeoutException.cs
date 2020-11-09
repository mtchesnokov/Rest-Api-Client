using System;

namespace Tch.HttpClient.Domain.Exceptions
{
   /// <summary>
   ///    This exception is thrown when external http service does not respond within specified timeout
   /// </summary>
   public class ExternalServiceTimeoutException : Exception
   {
      public string UsedHttpMethod { get; set; }

      public string ServiceUrl { get; set; }

      public int TimeoutSeconds { get; set; } 

      public ExternalServiceTimeoutException() : base("External Http service has not responded within specified timeout")
      {
      }
   }
}