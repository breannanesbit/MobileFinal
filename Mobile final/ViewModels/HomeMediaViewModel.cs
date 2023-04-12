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
        [RelayCommand]
        public async Task Start()
        {
            Url = "https://mobilemediastorage.blob.core.windows.net/pictures/665e813e-7e0b-45fb-9ddd-260716909c56";
           
        }
    }
}
