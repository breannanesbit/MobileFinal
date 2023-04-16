using Azure;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using MediaAPI.services;
using Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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
        public MediaController(BlobServiceClient blobclient, DatabaseService service)
        {
            video = blobclient.GetBlobContainerClient("videos");
            audio = blobclient.GetBlobContainerClient("audio");
            visual = blobclient.GetBlobContainerClient("pictures");
            database = service;
        }

        [HttpPut("uploadfile/video/{username}")]
        public async Task<string> UploadVideoFile(IFormFile file, string username)
        {
            User user = await database.GetUserByUsername(username);;
            if (user == null)
            {
                User newuser = new User
                {
                    FirstName = "N/A",
                    LastName = "N/A",
                    Username = username,

                };
                await database.PostUserAsync(newuser);
                user = await database.GetUserByUsername(username);;
            }
            // Generate a unique name for the new blob
            var blobName = await UploadFile(file, "video");
            var newMedia = new Media()
            {
                DateUpload = DateTime.Now,
                MediaKey = blobName,
                UserId = user.Id,
            };
            await database.PostMediaAsync(newMedia);
            Media mediawithID = await database.GetMediaByKey(blobName);
            
            Category cat = await database.GetCategory("Videos");
            var mediaCat = new MediaCategory()
            {
                CategoryId = cat.Id,
                MediaId = mediawithID.Id,
            };
            database.AddMediaCategory(mediaCat);
            return blobName;
        }

        [HttpPut("uploadfile/audio/{username}")]
        public async Task<string> UploadAudioFile(IFormFile file, string username)
        {
            User user = await database.GetUserByUsername(username);;
            if (user == null)
            {
                User newuser = new User
                {
                    FirstName = "N/A",
                    LastName = "N/A",
                    Username = username,

                };
                await database.PostUserAsync(newuser);
                user = await database.GetUserByUsername(username);
            }
            // Generate a unique name for the new blob
            var blobName = await UploadFile(file, "audio");
            
            var newMedia = new Media()
            {
                DateUpload = DateTime.Now,
                MediaKey = blobName,
                UserId = user.Id,
            };
            await database.PostMediaAsync(newMedia);
            Thread.Sleep(500);
            Media mediawithID = await database.GetMediaByKey(blobName);
            Thread.Sleep(500);
            Category cat = await database.GetCategory("Audios");
            var mediaCat = new MediaCategory()
            {
                CategoryId = cat.Id,
                MediaId = mediawithID.Id,
            };
            database.AddMediaCategory(mediaCat);
            return blobName;
        }

        [HttpPut("uploadfile/visual/{username}")]
        public async Task<string> UploadVisualFile(IFormFile file, string username)
        {

            User user = await database.GetUserByUsername(username);
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
           var blobName = await UploadFile(file, "visual");

            var newMedia = new Media()
            {
                DateUpload = DateTime.Now,
                MediaKey = blobName,
                UserId = user.Id,
            };
            await database.PostMediaAsync(newMedia);
            Thread.Sleep(500);
            Media mediawithID = await database.GetMediaByKey(blobName);

            Category cat = await database.GetCategory("Pictures");
            var mediaCat = new MediaCategory()
            {
                CategoryId = cat.Id,
                MediaId = mediawithID.Id,
            };
            database.AddMediaCategory(mediaCat);
            return blobName;
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

        [HttpGet("category/{categoryId}")]
         public async Task<Category> GetCategory(int categoryId)
        {
            return database.GetCategoryById(categoryId);
        }

        [HttpGet("getusermedia/{username}")]
        public async Task<IEnumerable<Media>> GetUserMedia(string username)
        {
            return database.GetMediaByUsername(username);
        }

        [HttpGet("getlatestmedia")]
        public async Task<List<Media>> GetLatestMediaAsync()
        {
            return await database.GetLatestMediaAsync();
        }

       /* [HttpGet("test/{test}")]
        public long SquareNumber(int test)
        {
            var newtest = (long)test;
            return newtest * newtest;
        }*/
    }
}
