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

        [HttpPost("v1/uploadfile/{type}/{username}/{filename}")]
        public async Task UploadAnyFile(string username, string type, string filename, IFormFile file)
        {
            string mediaBlobClient = "";
            string mediaCategory = "";
            int categoryId;
            switch (type)
            {
                case "video":
                    mediaBlobClient = "video";
                    mediaCategory = "Videos";
                    categoryId = 1;
                    break;
                case "audio":
                    mediaBlobClient = "audio";
                    mediaCategory = "Audios";
                    categoryId = 2;
                    break;
                case "visual":
                    mediaBlobClient = "visual";
                    mediaCategory = "Pictures";
                    categoryId = 3;
                    break;
                default:
                    Console.Write( "Error: Not an accepted format");
                    break;
            }
            string blobName = await mediaHelpSource.AddMedia(file, username, mediaBlobClient, mediaCategory, filename);

           // return blobName;
        }

        [HttpPost("v2/uploadfile/{type}/{username}/{filename}")]
        public async Task UploadAnyFileButAudio(string username, string type, string filename, IFormFile file)
        {
            string mediaBlobClient = "";
            string mediaCategory = "";
            int categoryId;
            switch (type)
            {
                case "video":
                    mediaBlobClient = "video";
                    mediaCategory = "Videos";
                    categoryId = 1;
                    break;
                case "visual":
                    mediaBlobClient = "visual";
                    mediaCategory = "Pictures";
                    categoryId = 3;
                    break;
                default:
                    Console.Write("Error: Not an accepted format");
                    break;
            }
            string blobName = await mediaHelpSource.AddMedia(file, username, mediaBlobClient, mediaCategory, filename);

            // return blobName;
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

        [HttpGet("v1/getlatestmedia")]
        public async Task<List<Media>> GetLatestMediaAsync()
        {
            return await database.GetLatestMediaAsync();
        }

        [HttpGet("v2/getlatestmedia/{count}")]
        public async Task<List<Media>> GetLatestMediaDynamicCountAsync(int count)
        {
            return await database.GetLatestMediaAsync(count);
        }

        [HttpGet("v1/getmediabykey/{mediaKey}")]
        public async Task<Media> GetMediaByKey(string mediaKey)
        {
            return await database.GetMediaByKey(mediaKey);
        }

        /* [HttpGet("test/{test}")]
         public long SquareNumber(int test)
         {
             var newtest = (long)test;
             return newtest * newtest;
         }*/
    }
}
