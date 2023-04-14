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
        private readonly BlobContainerClient video;
        private readonly BlobContainerClient audio;
        private readonly BlobContainerClient visual;
        private readonly DatabaseService database;
        public MediaControllerSource(BlobServiceClient blobclient, DatabaseService service)
        {
            video = blobclient.GetBlobContainerClient("videos");
            audio = blobclient.GetBlobContainerClient("audio");
            visual = blobclient.GetBlobContainerClient("pictures");
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


        public async Task addMediaCategory(string category, string blobName)
        {
            Media mediawithID = await database.GetMediaByKey(blobName);

            Category cat = await database.GetCategory(category);
            createMediaCategory(mediawithID, cat);
        }

        private void createMediaCategory(Media mediawithID, Category cat)
        {
            var mediaCat = new MediaCategory()
            {
                CategoryId = cat.Id,
                MediaId = mediawithID.Id,
            };
            database.AddMediaCategory(mediaCat);
        }

        public async Task<string> AddMedia(IFormFile file, string username, string clientname)
        {
            User user = await database.GetUserByUsername(username); ;

            // Generate a unique name for the new blob
            var blobName = await UploadFile(file, "video");
            await createAndAddMedia(user, blobName);
            return blobName;
        }

        private async Task createAndAddMedia(User user, string blobName)
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
