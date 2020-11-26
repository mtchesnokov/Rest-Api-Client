using System;

namespace Tch.RestClient.Domain.Objects
{
   public class RestClientOptions
   {
      /// <summary>
      ///    This is timeout we will wait till external service responds.
      ///    This defaults to 80 seconds
      /// </summary>
      public int ConnectionTimeoutSeconds { get; }

      #region ctor

      public RestClientOptions(int connectionTimeoutSeconds = 80)
      {
         if (connectionTimeoutSeconds <= 0)
         {
            throw new ArgumentException("Connection timeout should be positive non-zero number");
         }

         ConnectionTimeoutSeconds = connectionTimeoutSeconds;
      }

      #endregion
   }
}