using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace IDP_RPWebAPI.Controllers
{
    [EnableCors("angularapp_policy")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(JsonSerializer.Serialize("hello GEt"));
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post()
        {

            return Ok(JsonSerializer.Serialize("hello Post"));
        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public IActionResult Delete()
        {

            return Ok(JsonSerializer.Serialize("hello DELETE"));
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public IActionResult Put()
        {

            return Ok(JsonSerializer.Serialize("hello PUT"));
        }
    }
}
