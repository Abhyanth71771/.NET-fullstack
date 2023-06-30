using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure_WebApp.Controllers
{
    [EnableCors("angularapp_policy")]
    [Route("[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private IConfiguration config;
        private string connstring = "";
        public BlobController(IConfiguration config)
        {
            this.config = config;
            this.connstring = this.config.GetConnectionString("BlobConnectionString");
        }
        [Route("containers")]
        [HttpGet]
        public IActionResult GetContainers()
        {
            //1. get access to the blob service within the storage acc
            BlobServiceClient client = new BlobServiceClient(connstring);
            List<string> containers = new List<string>();

            //2. get a collection of all blob containers in the blob service
            foreach (var container in client.GetBlobContainers())
            {
                containers.Add(container.Name);
            }
            if (containers.Count == 0)
            {
                return NotFound("No containers found");
            }
            return Ok(containers);
        }
        [HttpGet]
        [Route("{containername}")]
        public IActionResult GetBlobs(string containername)
        {
            BlobContainerClient container =
                new BlobContainerClient(connstring, containername);

            if (!container.Exists().Value)
            {
                return NotFound("Blob container " + container.Name + " not found");
            }
            List<string> blobs = new List<string>();
            foreach (var blob in container.GetBlobs())
            {
                blobs.Add(blob.Name);
            }
            if (blobs.Count == 0)
            {
                return NotFound("No blobs in container " + containername);
            }
            return Ok(blobs);
        }
        [HttpGet]
        [Route("createcontainer/{containername}")]
        public IActionResult CreateContainer(string containername)
        {
            BlobContainerClient container =
                new BlobContainerClient(connstring, containername);

            if (container.Exists().Value)
            {
                return Conflict("Container named " + containername + " exists");
            }
            container.Create();
            return Ok("Container " + containername + " created");
        }
        [HttpPost]
        [Route("upload/{containername}")]
        public IActionResult UploadBlob(string containername,
                    IFormFile blob)
        {
            BlobContainerClient container =
               new BlobContainerClient(connstring, containername);

            if (!container.Exists().Value)
            {
                return NotFound("Container named " + containername + " not found");
            }
            container.UploadBlob(blob.FileName, blob.OpenReadStream());
            return Ok("Blob named " + blob.FileName + " uploaded");
        }

        [HttpGet]
        [Route("download/{containername}/{blobname}")]
        public IActionResult DownloadBlob(string containername, string blobname)
        {
            BlobContainerClient container =
               new BlobContainerClient(connstring, containername);

            if (!container.Exists().Value)
            {
                return NotFound("Container named " + containername + " not found");
            }
            BlobClient blob = container.GetBlobClient(blobname);
            if (!blob.Exists().Value)
            {
                return NotFound("Blob named " + blobname + " not found");
            }
            MemoryStream ms = new MemoryStream();
            blob.DownloadTo(ms);

            return File(ms.ToArray(), "application/octet-stream", blob.Name);
        }
    }

}

