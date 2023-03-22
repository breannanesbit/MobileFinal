using Azure;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

namespace MediaAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MediaController : Controller
    {
        private readonly BlobServiceClient blobclient;
        private readonly BlobContainerClient video;
        public MediaController(BlobServiceClient blobclient)
        {
            this.blobclient = blobclient;
            video = this.blobclient.GetBlobContainerClient("videos");
        }
      [HttpPut("uploadfile/{file}")]
        public async Task<string> UploadFile(IFormFile file)
        {

            // Generate a unique name for the new blob
            var blobName = Guid.NewGuid().ToString();

            // Upload the file to Blob Storage
            var blobClient = video.GetBlobClient(blobName);
            await blobClient.UploadAsync(file.OpenReadStream());

            // Return the key of the newly created blob
            return blobName;
        }

        [HttpGet("downloadfile/{blobKey}")]
        public async Task<IActionResult> DownloadFile(string blobKey)
        {


            // Get a reference to the blob
            BlobClient blobClient = video.GetBlobClient(blobKey);

            // Download the blob content
            var response = await blobClient.DownloadAsync();
            // Return the blob content as a stream
            var content = response.Value;
            return File(content.Content, content.ContentType);
        }
    }
}
