using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

namespace MediaAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MediaController : Controller
    {
        private readonly BlobServiceClient blobclient;
        public MediaController(BlobServiceClient blobclient)
        {
            this.blobclient = blobclient;
        }
        [HttpPut("uploadfile/{file}")]
        public async Task<string> UploadFile(IFormFile file)
        {
            var blobName = Guid.NewGuid().ToString();
            var containerclient = blobclient.GetBlobContainerClient("videos");
            var blobClient = containerclient.GetBlobClient(blobName);

            try
            {
                using (var stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream);
                }
            }
            catch (Exception ex)
            {
                // Add error handling logic here
                throw new Exception($"Failed to upload file: {ex.Message}");
            }

            return blobName;
        }
    }
}