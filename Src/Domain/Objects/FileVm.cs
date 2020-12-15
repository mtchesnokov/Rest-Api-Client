namespace Tch.RestClient.Domain.Objects
{
   /// <summary>
   /// This is help class that represents file that is sent over the wire
   /// </summary>
   public class FileVm
   {
      public string FileName { get; set; }

      public string ContentType { get; set; }

      public byte[] Content { get; set; }
   }
}