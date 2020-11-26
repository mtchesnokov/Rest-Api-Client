using Tch.RestClient.Domain.Objects;

namespace Tch.RestClient.UnitTests.TestExtensions
{
   public static class GetEmbeddedFileExtension2
   {
      public static OwnFile GetEmbeddedFile(this UnitTestBase test, string embeddedFileName)
      {
         return test.GetType().Assembly.GetEmbeddedFile(embeddedFileName);
      }
   }
}