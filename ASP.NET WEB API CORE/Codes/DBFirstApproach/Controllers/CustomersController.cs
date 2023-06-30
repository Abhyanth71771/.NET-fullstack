using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBFirstApproach.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("angularapp_policy")]
    public class CustomersController : ControllerBase
    {
        public IDataAccessService svm;
        public CustomersController(IDataAccessService svc)
        {
            this.svm = svc;

        }

        [HttpGet]
        [Route("allcustomers")]
        public IActionResult Get()
        {
            return Ok(this.svm.GetAllCustomers());
        }
        [HttpPost]
        [Route("addcustomer")]
        public IActionResult AddCustomer(Customer newcustomer)
        {
            try
            {
                this.svm.AddCustomer(newcustomer);
                int newcustomerid = newcustomer.Custid;
                string createduri = "http://localhost:5009/Customers/" + newcustomerid;



                //return status code 201
                return Created(createduri, "Customer added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "EXCEPTION: " + ex.InnerException?.Message);
            }
        }
        [HttpGet]
        [Route("{num:int}")] 
        public IActionResult Get(int num)
        {
            return Ok(this.svm.GetCustomerByID(num));
        }
        [HttpGet]
        [Route("customers/customer/location/{loc}")]
        public IActionResult Get(string loc)
        {
            return Ok(this.svm.GetCustomerByLoc(loc));   
        }
        [HttpGet]
        [Route("Customers/customer/name/{sw}")]
        public IActionResult Getchar(string sw)
        {
            return Ok(this.svm.GetCustomerByChar(sw));
        }

    }
}