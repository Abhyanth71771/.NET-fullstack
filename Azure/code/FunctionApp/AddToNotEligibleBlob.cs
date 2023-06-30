using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public class AddToNotEligibleBlob
    {
        [FunctionName("AddToNotEligibleBlob")]
        public void Run([QueueTrigger("noteligiblequeue")]
        string queuemessage,
            [Blob("common/common.txt", FileAccess.Read)] Stream common,
            [Blob("noteligibleblob/{DateTime}.txt", FileAccess.Write)] Stream eligible,
            ILogger log)
        {
            
            StreamReader sr=new StreamReader(common);
            string data=sr.ReadToEnd();
            sr.Close();
            log.LogInformation("Blob messege is Message is:" + data);

            StreamWriter sw = new StreamWriter(eligible);
            sw.WriteLine(data);
            sw.WriteLine(queuemessage);
            sw.Close();
            log.LogInformation("Data logged");
        }
    }
}
