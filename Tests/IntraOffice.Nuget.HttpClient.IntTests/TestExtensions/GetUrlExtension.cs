using System.Configuration;

namespace Tch.RestClient.IntTests.TestExtensions
{
   internal static class GetUrlExtension
   {
      public static string GetUrl(this IntegrationTestBase test, string relativeUrl)
      {
         return $"{ConfigurationManager.AppSettings["TestServerUrl"]}{relativeUrl}";
      }
   }
}