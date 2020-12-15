using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tch.FakeApi.Controllers
{
   public class GetController : ControllerBase
   {
      [HttpGet]
      [Route("get1")]
      public async Task<IActionResult> Get1()
      {
         await Task.Delay(1000);
         var model = new {Id = 123, Name = "Abc"};
         return Ok(model);
      }

      [HttpGet]
      [Route("get2")]
      public async Task<IActionResult> Get2()
      {
         await Task.Delay(1000);
         return StatusCode((int) HttpStatusCode.NotFound);
      }
   }
}