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

namespace Mobile_final.ViewModels
{
    public partial class HomeMediaViewModel : ObservableObject
    {

        [ObservableProperty]
        private Microsoft.Maui.Controls.Image imageView;

        [ObservableProperty]
        private string url;

        [ObservableProperty]
        private string url2;
        [RelayCommand]
        public async Task Start()
        {
            Url = "https://mobilemediastorage.blob.core.windows.net/pictures/665e813e-7e0b-45fb-9ddd-260716909c56";
            Url2 = "https://mobilemediastorage.blob.core.windows.net/videos/1ff70c40-f620-4519-818b-e09819ee7f96";
            //1ff70c40-f620-4519-818b-e09819ee7f96
        }


        //If media type is audio or video, turn on video, turn off image
        //if media type is visual, turn on image, turn off video
    }
}
