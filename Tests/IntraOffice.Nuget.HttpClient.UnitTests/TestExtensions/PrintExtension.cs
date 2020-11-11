using System;
using Newtonsoft.Json;

namespace Tch.RestClient.UnitTests.TestExtensions
{
   public static class PrintExtension
   {
      public static void Print(this object obj)
      {
         Console.WriteLine($"\n{obj.GetType().Name}:\r" + JsonConvert.SerializeObject(obj, Formatting.Indented));
      }
   }
}