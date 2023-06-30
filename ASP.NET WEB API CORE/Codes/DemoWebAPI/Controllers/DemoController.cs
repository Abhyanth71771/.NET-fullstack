using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class demoController : ControllerBase //we need not create any object 
    {
        [HttpGet]
        public string Get()
        {
            return "GET";
        }
        [HttpPost]
        public string Post()
        {
            return "POST";
        }
        [HttpDelete]
        public string Delete()
        {
            return "DELETE";
        }



        [HttpPut]
        public string Put()
        {
            return "PUT";
        }
    }
}
