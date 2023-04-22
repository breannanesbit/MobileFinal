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

            if (MediaKey.Contains("videos") || MediaKey.Contains("audios"))
            {
                Isplayer = true;
                Isimage = false;
            }
            else if (MediaKey.Contains("pictures"))
            {
                Isplayer = false;
                Isimage = true;
            }
            Url = MediaKey;
 
        }

    }
}
