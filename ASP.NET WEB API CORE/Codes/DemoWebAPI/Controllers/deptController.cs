using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class deptController : ControllerBase
    {
        
        string[] dept = { "Training", "Staffing", "HR", "Finance", "HouseKeeping" };
        [HttpGet]
        public string[] get()
        {
            return dept;
        }
        [HttpPost]
        public string post()
        { 
            return dept[0];
        }
        [HttpDelete]
        public string delete()
        {
            return dept[4];
        }
        [HttpPut] 
        public string put()
        {
            return dept[0]+" " + dept[4];
        }
    }
}
