namespace Tch.RestClient.Domain.Objects
{
   public class OwnFile
   {
      public string FileName { get; set; }

      public string ContentType { get; set; }

      public byte[] Content { get; set; }
   }
}