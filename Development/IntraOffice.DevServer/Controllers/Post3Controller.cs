using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tch.FakeApi.Controllers
{
   public class Post3Controller : ControllerBase
   {
      [Route("post3")]
      [HttpPost]
      public async Task<IActionResult> Post()
      {
         await Task.Delay(1000);

         return StatusCode(500);
      }
   }
}