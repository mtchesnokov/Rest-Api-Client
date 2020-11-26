using System;
using System.Reflection;

namespace Tch.RestClient.UnitTests.TestExtensions
{
   public static class GetEmbeddedBytesExtension
   {
      /// <summary>
      ///    Get content of embedded file
      /// </summary>
      /// <param name="assembly"></param>
      /// <param name="embeddedFileName"></param>
      /// <returns></returns>
      public static byte[] GetEmbeddedBytes(this Assembly assembly, string embeddedFileName)
      {
         if (assembly == null)
         {
            throw new ArgumentNullException(nameof(assembly));
         }

         if (string.IsNullOrEmpty(embeddedFileName))
         {
            throw new ArgumentNullException(nameof(embeddedFileName));
         }

         var embeddedStream = assembly.GetEmbeddedStream(embeddedFileName);
         var buffer = new byte[embeddedStream.Length];
         embeddedStream.Read(buffer, 0, (int) embeddedStream.Length);
         return buffer;
      }
   }
}