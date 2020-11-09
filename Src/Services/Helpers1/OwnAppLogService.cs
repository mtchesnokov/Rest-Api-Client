using Tch.HttpClient.Interfaces.Helpers1;

namespace Tch.HttpClient.Services.Helpers1
{
   internal class OwnAppLogService : IOwnAppLogService
   {
      private const string Category = "IntraOffice.Nuget.HttpClient";

      [SetterProperty]
      public IAppLogService AppLogService { get; set; }

      public void LogDebug(string message, object context = null)
      {
         AppLogService.LogDebug(message, context, Category);
      }

      public void LogWarning(string message, object context = null)
      {
         AppLogService.LogWarning(message, context, Category);
      }
   }
}