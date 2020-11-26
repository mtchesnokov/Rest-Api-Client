namespace Tch.RestClient.IntTests.TestExtensions
{
   internal static class GetUrlExtension
   {
      public static string GetUrl(this TestBase test, string relativeUrl)
      {
         return $"{ConfigurationManager.AppSettings["TestServerUrl"]}{relativeUrl}";
      }
   }
}