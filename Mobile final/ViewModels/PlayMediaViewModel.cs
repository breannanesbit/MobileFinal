using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.Maui.Graphics;
using Azure.Storage.Blobs;
using System.IO;
using Microsoft.Maui.ApplicationModel;
using System.Drawing;
using Shared;
using Mobile_final.Services;

namespace Mobile_final.ViewModels
{
    [QueryProperty(nameof(MediaKey), "mediaKey")]
    //[QueryProperty(nameof(MediaCategories), "mediaCategories")]
    public partial class PlayMediaViewModel : ObservableObject
    {
        private UserService client;
        public PlayMediaViewModel(UserService service)
        {

            client = service;

        }

        [ObservableProperty]
        private Microsoft.Maui.Controls.Image imageView;

        [ObservableProperty]
        private string mediaKey;


        [ObservableProperty]
        private bool isplayer;

        [ObservableProperty]
        private bool isimage;

        [ObservableProperty]
        private string url;

        [RelayCommand]
        public async Task Start()
        {
            
            
                /*Category cat = await client.GetCategory(item.CategoryId);

                if (cat.Category1 == "Videos" || cat.Category1 == "Audios")
                {
                    Isplayer = true;
                    Isimage = false;
                    if(cat.Category1 == "Videos")
                    {
                        Url = $"https://mobilemediastorage.blob.core.windows.net/videos/{MediaKey}";
                    }
                    else
                    {
                        Url = $"https://mobilemediastorage.blob.core.windows.net/audios/{MediaKey}";
                    }
                    
                }
                else if (cat.Category1 == "Pictures")
                {
                    Isplayer = false;
                    Isimage = true;
                    Url = $"https://mobilemediastorage.blob.core.windows.net/pictures/{MediaKey}";
                    
                }
                else
                {
                    Isplayer = false;
                    Isimage = false;
                    
                }*/
            
        }

        //accept media as paramters
        //make function to determine what type it is. Audio and video are category 2 and 1, visual is 3

        //If media type is audio or video, turn on video, turn off image
        //if media type is visual, turn on image, turn off video
        //use media key as source
    }
}
