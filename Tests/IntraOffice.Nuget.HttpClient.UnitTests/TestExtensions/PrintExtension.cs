using System.Diagnostics;
using Newtonsoft.Json;

namespace Tch.HttpClient.UnitTests.TestExtensions
{
   public static class PrintExtension
   {
      public static void Print(this object obj)
      {
         Debug.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));
      }
   }
}