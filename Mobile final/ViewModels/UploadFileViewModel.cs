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

        [ObservableProperty]
        private string fileName;

        [ObservableProperty]
        private bool mediaOptionSelected;

        [ObservableProperty]
        private string username;

        //[ObservableProperty]
        private string selectedOption;


        public string SelectedOption
        {
            get { return selectedOption; }
            set
            {
                SetProperty(ref selectedOption, value);
            }
        }

        [RelayCommand]
        public void Start()
        {
            MediaOptionSelected = false;

        }

        [RelayCommand]
        public async Task PickFileToUpload()
        {
            var result = await FilePicker.Default.PickAsync();
            if (result == null)
            {
                await PickFileToUpload();
            }
            else
            {
                FilePath = result.FullPath;
            }

        }

        [RelayCommand]
        public async Task UploadFile()
        {
           if(FileName.Length > 0 && FileName != "Please enter a file name")
           {
                MultipartFormDataContent form;
                FileStream fileStream;
                StreamContent fileContent;
                var convertedForm = ConvertFileType(out form, out fileStream, out fileContent);
                switch (SelectedOption)
                {
                    case "Video":
                        await client.PutAsync($"uploadfile/video/{Username}/{FileName}", convertedForm);
                        break;
                    case "Audio":
                        await client.PutAsync($"uploadfile/audio/{Username}/{FileName}", convertedForm);
                        break;
                    case "Visual":
                        await client.PutAsync($"uploadfile/pictures/{Username}/{FileName}", convertedForm);
                        break;
                }
           }
           else
           {
                FileName = "Please enter a file name";
           }
           
            
            //Blobkey = await response.Content.ReadAsStringAsync();

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

    }
}
