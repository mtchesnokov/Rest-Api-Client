using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tch.FakeApi.Models;

namespace Tch.FakeApi.Controllers
{
   public class Post1Controller : ControllerBase
   {
      [HttpPost]
      [Route("post1")]
      public async Task<IActionResult> Post([FromBody] CreateModel model)
      {
         Debug.WriteLine("Post1Controller model received: " + JsonConvert.SerializeObject(model, Formatting.Indented));

         await Task.Delay(1000);

         return Created("dummy", new CreatedModel {Id = 123, Name = model.Name});
      }
   }
}