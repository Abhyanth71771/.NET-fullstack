using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
        HttpRequest req,
            [Queue("eligiblequeue")] IAsyncCollector<string> eligiblequeue,
            [Queue("noteligiblequeue")] IAsyncCollector<string> noteligiblequeue,
            ILogger log)
        {
            string votername = req.Query["votername"];
            string age = req.Query["age"];    
            if (string.IsNullOrEmpty(votername) || string.IsNullOrEmpty(age))
            {
                return new NotFoundObjectResult("Votername or age or both are missing");
            }
            if (int.Parse(age) > 18)
            {
                string messege = votername + " aged " + age + " is eligible to vote";
                eligiblequeue.AddAsync(messege); 
            }
            else
            {
                string messege = votername + " aged " + age + " is not  eligible to vote";
                noteligiblequeue.AddAsync(messege);
            }
            return new OkObjectResult("Message writen to queue");
        }
    }
}
