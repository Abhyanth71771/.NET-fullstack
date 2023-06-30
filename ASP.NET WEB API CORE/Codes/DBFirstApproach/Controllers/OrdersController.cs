using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBFirstApproach.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("angularapp_policy")]
    public class OrdersController : ControllerBase
    {
        public IDataAccessService svm;
        public OrdersController(IDataAccessService svc) 
        {
            this.svm = svc;
        }
        [HttpGet]
        
        public IActionResult GetOrders()
        {
            return Ok(this.svm.GetAllOrders());
        }
        [HttpGet]
        [Route("cust/{id}")]
        public IActionResult GetCustomer(int id)
        {
            var ord = this.svm.GetCustomerByOrderID(id);
            return Ok(ord);
        }
        [HttpGet]
        [Route("orders/{id}")]
        public IActionResult GetOrders(int id)
        {
            return Ok(this.svm.GetOrdersbyCustomerID(id));
        }


    }
}
