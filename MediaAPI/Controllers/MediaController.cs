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



        [HttpPost, Route("v1/uploadfile/{type}/{username}/{filename}"), HttpHeader("version", "1.0")]
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
                    Console.Write("Error: Not an accepted format");
                    break;
            }
            string blobName = await mediaHelpSource.AddMedia(file, username, mediaBlobClient, mediaCategory, filename);

            // return blobName;
        }

        [HttpPost, Route("v2/uploadfile/{type}/{username}/{filename}"), HttpHeader("version", "2.0")]
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


        [HttpGet("v1/category/{categoryId}")]
        public async Task<Category> GetCategory(int categoryId)
        {
            return database.GetCategoryById(categoryId);
        }

        [HttpGet("v1/getusermedia/{username}")]
        public async Task<IEnumerable<Media>> GetUserMedia(string username)
        {
            return database.GetMediaByUsername(username);
        }

        [HttpGet, Route("v1/getlatestmedia"), HttpHeader("version", "1.0")]
        //[HttpGet("v1/getlatestmedia")]
        public async Task<IActionResult> GetLatestMediaAsync()
        {
            var media = await database.GetLatestMediaAsync();
            // return media;
            return Ok(media);
        }

        [HttpGet, Route("v2/getlatestmedia/{count}"), HttpHeader("version", "2.0")]
        public async Task<IActionResult> GetLatestMediaDynamicCountAsync(int count)
        {
            var media = await database.GetLatestMediaAsync(count);
            return Ok(media);
        }

        [HttpGet("v1/getmediabykey/{mediaKey}")]
        public async Task<Media> GetMediaByKey(string mediaKey)
        {
            return await database.GetMediaByKey(mediaKey);
        }

        [HttpPost("/media/likes/{incrementor}")]
        public async Task SubmitALike(Media media, int incrementor)
        {
            if (incrementor == 1)
            {
                database.IncreaseLikes(media, 1);
            }
            else
            {
                database.IncreaseLikes(media, -1);
            }

        }

        /* [HttpGet("test/{test}")]
         public long SquareNumber(int test)
         {
             var newtest = (long)test;
             return newtest * newtest;
         }*/
    }
}
