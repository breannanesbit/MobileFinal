using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Mobile_final.ViewModels
{
    public partial class UploadFileViewModel : ObservableObject
    {
        private readonly HttpClient client;
        public UploadFileViewModel(HttpClient client)
        {
            this.client = client;
        }
        [ObservableProperty]
        private string filePath;

        [ObservableProperty]
        private string blobkey;

        [RelayCommand]
        public async Task PickFileToUpload()
        {
            var result = await FilePicker.Default.PickAsync();
            FilePath = result.FullPath;
        }

        [RelayCommand]
        public async Task UploadFile()
        {
            using var form = new MultipartFormDataContent();
            using var fileStream = new FileStream(FilePath, FileMode.Open);
            using var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            form.Add(fileContent, "file", Path.GetFileName(FilePath));

            var response = await client.PutAsync($"uploadfile/{Path.GetFileName(FilePath)}", form);
            Blobkey = await response.Content.ReadAsStringAsync();

        }
    }
}