using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBFirstApproach.Controllers
{
    [EnableCors("angularapp_policy")]
    [Route("customer/addcustomer")]
    [ApiController]
    [ApiVersion("1.1")]
    
    public class CustomersV2Controller : ControllerBase
    {
        public IDataAccessService svm;
        public CustomersV2Controller(IDataAccessService svc)
        {
            this.svm = svc;

        }
       
        [HttpPost]
        public IActionResult PostPutCustomer(Customer newcustomer)
        {
            var cust = this.svm.FindCustomer(newcustomer.Custid);
            if (cust != null)
            {
                return Ok(this.svm.EditCustomer(newcustomer));
            }
            else
            {
                this.svm.AddCustomer(newcustomer);
                int newcustomerid = newcustomer.Custid;
                string createduri = "http://localhost:5009/Customers/" + newcustomerid;
                string response = "Customer Created with Name " + newcustomer.Custname + " and location is " + newcustomer.Location;

                //return status code 201
                return Ok(newcustomer);
            }

        }
        [HttpGet]
        [Route("location")]
        public IActionResult GetLocations()
        {
            string[] states = {"Andaman and Nicobar Islands",
    "Andhra Pradesh",
    "Arunachal Pradesh",
    "Assam",
    "Bihar",
    "Chandigarh",
    "Chhattisgarh",
    "Dadra and Nagar Haveli and Daman and Diu",
    "Goa",
    "Gujurat",
    "Haryana",
    "Himachal Pradesh",
    "Jammu and Kashmir",
    "Jharkhand",
    "Karnataka",
    "Kerela",
    "Ladakh",
    "Lakshadweep",
    "Madhya Pradesh",
    "Maharashtra",
    "Manipur",
    "Meghalaya",
    "Mizoram",
    "Nagaland",
    "NCT of Delhi",
    "Odisha",
    "Puducherry",
    "Punjab",
    "Rajasthan",
    "Sikkim",
    "Tamil Nadu",
    "Telangana",
    "Tripura",
    "Uttarakhand",
    "Uttar Pradesh",
    "West Bengal"};
            return Ok(states);
        }


    }
}
