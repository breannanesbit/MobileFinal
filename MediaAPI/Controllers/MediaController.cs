using Azure;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using MediaAPI.services;
using Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MediaController : Controller
    {

        private readonly BlobContainerClient video;
        private readonly BlobContainerClient audio;
        private readonly BlobContainerClient visual;
        private readonly DatabaseService database;
        public MediaController(BlobServiceClient blobclient)
        {
            video = blobclient.GetBlobContainerClient("videos");
            audio = blobclient.GetBlobContainerClient("audio");
            visual = blobclient.GetBlobContainerClient("pictures");
        }

        [HttpPost("uploadfile/video/{username}")]
        public async void UploadVideoFile(IFormFile file, string username)
        {
            var user = database.GetUserByUsername(username);;
            if (user == null)
            {
                User newuser = new User
                {
                    FirstName = "N/A",
                    LastName = "N/A",
                    Username = username,

                };
                await database.PostUserAsync(newuser);
                user = database.GetUserByUsername(username);;
            }
            // Generate a unique name for the new blob
            var blobName = Guid.NewGuid().ToString();
            BlobClient blobClient;
            // Upload the file to Blob Storage


            blobClient = video.GetBlobClient(blobName);
            await blobClient.UploadAsync(file.OpenReadStream());

            var newMedia = new Media()
            {
                DateUpload = DateTime.Now,
                MediaKey = blobName,
                UserId = user.Id,
            };
            database.AddMedia(newMedia);
            Media mediawithID = await database.GetMediaByKey(blobName);

            var cat = database.GetCategory("video");
            var mediaCat = new MediaCategory()
            {
                CategoryId = cat.Id,
                MediaId = mediawithID.Id,
            };
            database.AddMediaCategory(mediaCat);
        }
        [HttpPost("uploadfile/audio/{username}")]
        public async void UploadAudioFile(IFormFile file, string username)
        {
            var user = database.GetUserByUsername(username);;
            if (user == null)
            {
                User newuser = new User
                {
                    FirstName = "N/A",
                    LastName = "N/A",
                    Username = username,

                };
                await database.PostUserAsync(newuser);
                _ = database.GetUserByUsername(username);;
            }
            // Generate a unique name for the new blob
            var blobName = Guid.NewGuid().ToString();
            BlobClient blobClient;
            // Upload the file to Blob Storage


            blobClient = audio.GetBlobClient(blobName);
            await blobClient.UploadAsync(file.OpenReadStream());

            var newMedia = new Media()
            {
                DateUpload = DateTime.Now,
                MediaKey = blobName,
                UserId = user.Id,
            };
            database.AddMedia(newMedia);
            Media mediawithID = await database.GetMediaByKey(blobName);

            var cat = database.GetCategory("audio");
            var mediaCat = new MediaCategory()
            {
                CategoryId = cat.Id,
                MediaId = mediawithID.Id,
            };
            database.AddMediaCategory(mediaCat);
        }
        [HttpPost("uploadfile/visual/{username}")]
        public async void UploadVisualFile(IFormFile file, string username)
        {
            var user = database.GetUserByUsername(username);;
            if (user == null)
            {
                User newuser = new User
                {
                    FirstName = "N/A",
                    LastName = "N/A",
                    Username = username,

                };
                await database.PostUserAsync(newuser);
                _ = database.GetUserByUsername(username);
            }
            // Generate a unique name for the new blob
            var blobName = Guid.NewGuid().ToString();
            BlobClient blobClient;
            // Upload the file to Blob Storage


            blobClient = visual.GetBlobClient(blobName);
            await blobClient.UploadAsync(file.OpenReadStream());

            var newMedia = new Media()
            {
                DateUpload = DateTime.Now,
                MediaKey = blobName,
                UserId = user.Id,
            };
            database.AddMedia(newMedia);
            Media mediawithID = await database.GetMediaByKey(blobName);

            var cat = database.GetCategory("visual");
            var mediaCat = new MediaCategory()
            {
                CategoryId = cat.Id,
                MediaId = mediawithID.Id,
            };
            database.AddMediaCategory(mediaCat);
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
