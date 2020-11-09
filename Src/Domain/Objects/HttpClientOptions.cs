using System;

namespace Tch.HttpClient.Domain.Objects
{
   public class HttpClientOptions
   {
      /// <summary>
      ///    This is timeout we will wait till external service responds
      /// </summary>
      public int ConnectionTimeoutSeconds { get; }

      #region ctor

      public HttpClientOptions(int connectionTimeoutSeconds = 80)
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