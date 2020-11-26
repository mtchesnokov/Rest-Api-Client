using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Tch.RestClient.UnitTests.TestExtensions
{
   internal static class GetEmbeddedStreamExtension
   {
      /// <summary>
      ///    Open read stream to embedded file
      /// </summary>
      /// <param name="assembly"></param>
      /// <param name="embeddedFileName"></param>
      /// <returns></returns>
      public static Stream GetEmbeddedStream(this Assembly assembly, string embeddedFileName)
      {
         if (assembly == null)
         {
            throw new ArgumentNullException(nameof(assembly));
         }

         if (string.IsNullOrEmpty(embeddedFileName))
         {
            throw new ArgumentNullException(nameof(embeddedFileName));
         }

         embeddedFileName = embeddedFileName.ToLower();

         var resourceNames = assembly.GetManifestResourceNames();
         var resourceName = resourceNames.FirstOrDefault(r => r.ToLower().EndsWith(embeddedFileName));

         if (string.IsNullOrEmpty(resourceName))
         {
            throw new ArgumentException($"Embedded file {embeddedFileName} cannot be found");
         }

         return assembly.GetManifestResourceStream(resourceName);
      }
   }
}