using System.Text.Json.Serialization;

namespace Tch.FakeApi.Models
{
   public class ReceivedFile
   {
      public string ContentType { get; set; }

      [JsonIgnore]
      public byte[] Content { get; set; }

      public string FileName { get; set; }
   }
}