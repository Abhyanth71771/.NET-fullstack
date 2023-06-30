using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace DemoWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class employeeController : ControllerBase
    {
        string[] employee = { "Chirag", "Namit", "Sarthak", "Tejas", "Abhyanth" };
      
        [HttpGet]
        public string[] get()
        {
            return employee;
        }
        [HttpPost]
        public string post()
        { 
            return employee[0];
        }
        [HttpDelete]
        public string delete()
        {
            return employee[4];
        }
        [HttpPut] 
        public string put()
        {
            return employee[0]+"  " + employee[4];
        }

    }
}
