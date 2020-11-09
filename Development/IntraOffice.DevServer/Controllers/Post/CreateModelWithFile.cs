using Tch.FakeApi.Models;

namespace Tch.FakeApi.Controllers.Post
{
   public class CreateModelWithFile
   {
      public string Name { get; set; }

      public ReceivedFile File { get; set; }
   }
}