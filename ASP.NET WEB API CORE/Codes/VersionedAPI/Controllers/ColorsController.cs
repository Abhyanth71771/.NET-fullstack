using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VersionedAPI.Controllers
{
    [Route("/allcolors")]
    //[Route("v{version:apiVersion}/allcolors")]
    //[Route("/allcolors")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ColorsController : ControllerBase
    {
        [HttpGet]
        
        public IActionResult Get()
        {
            string[] colors = {"VERSION1", "RED", "GREEN" };
            return Ok(colors);
        }
    }
}
