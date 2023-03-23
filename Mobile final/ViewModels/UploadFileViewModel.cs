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

        [ObservableProperty]
        private MemoryStream videoFile;

        [RelayCommand]
        public async Task PickFileToUpload()
        {
            var result = await FilePicker.Default.PickAsync();
            if (result == null)
            {
                PickFileToUpload();
            }
            else
            {
                FilePath = result.FullPath;
            }

        }

        [RelayCommand]
        public async Task UploadFile()
        {
            MultipartFormDataContent form;
            FileStream fileStream;
            StreamContent fileContent;
            var convertedForm = ConvertFileType(out form, out fileStream, out fileContent);

            var response = await client.PutAsync($"uploadfile/video", convertedForm);
            Blobkey = await response.Content.ReadAsStringAsync();

        }

        private MultipartFormDataContent ConvertFileType(out MultipartFormDataContent form, out FileStream fileStream, out StreamContent fileContent)
        {
            form = new MultipartFormDataContent();
            fileStream = new FileStream(FilePath, FileMode.Open);
            fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            form.Add(fileContent, "file", Path.GetFileName(FilePath));

            return form;
        }

        [RelayCommand]
        public async Task DownloadFile()
        {
            var response = await client.GetAsync($"downloadfile/{Blobkey}");

            if (response.IsSuccessStatusCode)
            {
                byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();

                // Create a MemoryStream from the byte[] array
                MemoryStream memoryStream = new MemoryStream(fileBytes);
                VideoFile = memoryStream;
            }
        }
    }
}
