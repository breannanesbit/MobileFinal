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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MediaAPI.services
{
    public class MediaControllerSource
    {
        private readonly BlobContainerClient videoclient;
        private readonly BlobContainerClient audioclient;
        private readonly BlobContainerClient visualclient;
        private readonly DatabaseService database;
        public MediaControllerSource(BlobServiceClient blobclient, DatabaseService service)
        {
            videoclient = blobclient.GetBlobContainerClient("videos");
            audioclient = blobclient.GetBlobContainerClient("audio");
            visualclient = blobclient.GetBlobContainerClient("pictures");
            database = service;
        }


        public async Task<string> UploadFile(IFormFile file, string type)
        {

            // Generate a unique name for the new blob
            var blobName = Guid.NewGuid().ToString();
            BlobClient blobClient;
            // Upload the file to Blob Storage
            switch (type)
            {
                case "video":
                    blobClient = videoclient.GetBlobClient(blobName);
                    await blobClient.UploadAsync(file.OpenReadStream());
                    break;
                case "audio":
                    blobClient = audioclient.GetBlobClient(blobName);
                    await blobClient.UploadAsync(file.OpenReadStream());
                    break;
                case "visual":
                    blobClient = visualclient.GetBlobClient(blobName);
                    await blobClient.UploadAsync(file.OpenReadStream());
                    break;
            }
            // Return the key of the newly created blob
            return blobName;
        }


        public async Task addMediaCategory(string category, string blobName)
        {
            Media mediawithID = await database.GetMediaByKey(blobName);

            Category cat = await database.GetCategory(category);
            createMediaCategory(mediawithID, cat);
        }

        private void createMediaCategory(Media media, Category category)
        {
            /*var mediaCategory = new MediaCategory()
            {
                CategoryId = category.Id,
                MediaId = media.Id,
            };
            database.AddMediaCategory(mediaCategory);*/
        }

        public async Task<string> AddMedia(IFormFile file, string username, string clientname, string mediaCategory)
        {
            User user = await database.GetUserByUsername(username);

            // Generate a unique name for the new blob
            var blobName = await UploadFile(file, clientname);
            await createAndAddMedia(user, blobName, mediaCategory);
            return blobName;
        }

        public async Task createAndAddMedia(User user, string blobName, string clientname)
        {
            var newMedia = new Media()
            {
                DateUpload = DateTime.Now,
                MediaKey = blobName,
                UserId = user.Id,
               
            };
            await database.PostMediaAsync(newMedia);
        }
    }
}
