using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBFirstApproach.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("angularapp_policy")]
    public class GreetController : ControllerBase
    {
        [HttpGet]
        public IActionResult SayHello()
        {
            return Ok("hello");
        }
    }
}
