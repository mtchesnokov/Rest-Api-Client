using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tch.FakeApi.Services;

namespace Tch.FakeApi.Controllers.Post
{
   public class Post2Controller : ControllerBase
   {
      [Route("post2")]
      [HttpPost]
      public async Task<IActionResult> Post([ModelBinder(typeof(CustomModelBinder))] CreateModelWithFile model)
      {
         Debug.WriteLine("Model received");
         Debug.WriteLine(JsonConvert.SerializeObject(model));

         await Task.Delay(1000);

         return Created("dummy", new CreatedModel {Name = model.Name, Id = 123});
      }
   }
}