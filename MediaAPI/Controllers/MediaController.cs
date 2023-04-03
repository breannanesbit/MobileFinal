using Azure;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

namespace MediaAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MediaController : Controller
    {
        private readonly BlobContainerClient video;
        private readonly BlobContainerClient audio;
        private readonly BlobContainerClient visual;
        public MediaController(BlobServiceClient blobclient)
        {
            video = blobclient.GetBlobContainerClient("videos");
            audio = blobclient.GetBlobContainerClient("audio");
            visual = blobclient.GetBlobContainerClient("pictures");
        }
        [HttpPut("uploadfile/{type}")]
        public async Task<string> UploadFile(IFormFile file, string type)
        {

            // Generate a unique name for the new blob
            var blobName = Guid.NewGuid().ToString();
            BlobClient blobClient;
            // Upload the file to Blob Storage
            switch (type)
            {
                case "video":
                    blobClient = video.GetBlobClient(blobName);
                    await blobClient.UploadAsync(file.OpenReadStream());
                    break;
                case "audio":
                    blobClient = audio.GetBlobClient(blobName);
                    await blobClient.UploadAsync(file.OpenReadStream());
                    break;
                case "visual":
                    blobClient = visual.GetBlobClient(blobName);
                    await blobClient.UploadAsync(file.OpenReadStream());
                    break;
            }
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

        [HttpGet("test/{test}")]
        public int SquareNumber(int test)
        {
            return test * test;
        }
    }
}
