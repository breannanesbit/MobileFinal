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
        private readonly DatabaseService database;
        private readonly MediaControllerSource mediaHelpSource;
        public MediaController(BlobServiceClient blobclient, DatabaseService service, MediaControllerSource mediasource)
        {
           
            database = service;
            mediaHelpSource = mediasource;
        }

   /*     [HttpPut("uploadfile/video/{username}")]
        public async Task<string> UploadVideoFile(IFormFile file, string username)
        {
            string blobName = await mediaSource.AddMedia(file, username, "video");
            await mediaSource.addMediaCategory("Videos", blobName);
            return blobName;
        }


        [HttpPut("uploadfile/audio/{username}")]
        public async Task<string> UploadAudioFile(IFormFile file, string username)
        {
            string blobName = await mediaSource.AddMedia(file, username, "audio");
            await mediaSource.addMediaCategory("Audios", blobName);
            return blobName;
        }

        [HttpPut("uploadfile/visual/{username}")]
        public async Task<string> UploadVisualFile(IFormFile file, string username)
        {
            string blobName = await mediaSource.AddMedia(file, username, "visual");
            await mediaSource.addMediaCategory("Pictures", blobName);
            return blobName;
        }*/

        [HttpPut("uploadfile/{type}/{username}")]
        public async Task<string> UploadAnyFile(IFormFile file, string username, string type)
        {
            string mediaBlobClient;
            string mediaCategory;
            switch (type)
            {
                case "video":
                    mediaBlobClient = "video";
                    mediaCategory = "Videos";
                    break;
                case "audio":
                    mediaBlobClient = "audio";
                    mediaCategory = "Audios";
                    break;
                case "visual":
                    mediaBlobClient = "visual";
                    mediaCategory = "Pictures";
                    break;
                default:
                    return "Error: Not an accepted format";
            }
            string blobName = await mediaHelpSource.AddMedia(file, username, mediaBlobClient);
            await mediaHelpSource.addMediaCategory(mediaCategory, blobName);

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
            return database.GetLatestMediaAsync();
        }

       /* [HttpGet("test/{test}")]
        public long SquareNumber(int test)
        {
            var newtest = (long)test;
            return newtest * newtest;
        }*/
    }
}
