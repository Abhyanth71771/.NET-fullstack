using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBFirstApproach.Controllers
{
    [EnableCors("angularapp_policy")]
    [Route("customer/addcustomer")]
    [ApiController]
    [ApiVersion("1.0")]
    
    public class CustomersV1Controller : ControllerBase
    {
        public IDataAccessService svm;
        public CustomersV1Controller(IDataAccessService svc)
        {
            this.svm = svc;

        }
        [HttpPost]
        public IActionResult AddCustomer(Customer newcustomer)
        {
            try
            {
                this.svm.AddCustomer(newcustomer);
                int newcustomerid = newcustomer.Custid;
                string createduri = "http://localhost:5009/Customers/" + newcustomerid;



                //return status code 201
                return Ok(newcustomer);
            }
            catch (Exception ex)
            {
                return BadRequest("EXCEPTION: " + "Customer Alrady Exixts");
            }
        }
        


    }
}
