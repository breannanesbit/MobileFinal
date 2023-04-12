using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Http;

namespace Mobile_final.ViewModels
{
    public partial class HomeMediaViewModel : ObservableObject
    {

        [ObservableProperty]
        private string source;

        [RelayCommand]
        public static async Task Start()
        {
            var url = "http://mobilemediastorage.blob.core.windows.net/videos/665e813e-7e0b-45fb-9ddd-260716909c56";
            var httpClient = new HttpClient();
            var imageData = await httpClient.GetByteArrayAsync(url);
            var base64String = Convert.ToBase64String(imageData);
            var imageSource = $"data:image/png;base64,{base64String}";
            Source = imageSource;
        }
    }
}
