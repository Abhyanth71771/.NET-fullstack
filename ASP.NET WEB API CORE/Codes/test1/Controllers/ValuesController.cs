using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [BasicAuthentication]
        public string Get()
        {
            return "WebAPI Method Called";
        }
    }
}
