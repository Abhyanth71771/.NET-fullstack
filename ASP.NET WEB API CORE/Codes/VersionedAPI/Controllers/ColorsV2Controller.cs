using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VersionedAPI.Controllers
{
    [Route("/allcolors")]
    //[Route("/allcolors")]

    //[Route("v{version:apiVersion}/allcolors")]
    //[Route("/{ApiVersion}/allcolors")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ColorsV2Controller : ControllerBase
    {
        [HttpGet]
        
        public IActionResult Get()
        {
            string[] colors = { "VERSION2","RED", "GREEN","BLUE","BLACK" };
            return Ok(colors);
        }
    }
}
