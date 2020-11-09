namespace Tch.HttpClient.Interfaces.Helpers1
{
   internal interface IOwnAppLogService
   {
      void LogDebug(string message, object context = null);

      void LogWarning(string message, object context = null);
   }
}