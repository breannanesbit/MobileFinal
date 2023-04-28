using System.Net.Http.Headers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Services;

namespace Mobile_final.ViewModels
{
    public partial class UploadFileViewModel : ObservableObject
    {

        private readonly IUserService service;
        private readonly INavigationService nag;

        public ContentPage Page { get; set; } = new();

        public UploadFileViewModel(IUserService service/*, INavigationService nag*/)
        {
            this.service = service;
            //this.nag = nag;
        }
        [ObservableProperty]
        private string filePath;

        [ObservableProperty]
        private MemoryStream videoFile;

        [ObservableProperty]
        private string fileName;

        [ObservableProperty]
        private bool mediaOptionSelected;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string output;

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
                string type = ""; 
                var convertedForm = ConvertFileType(out form, out fileStream, out fileContent);
                switch (SelectedOption)
                {
                    case "Video":
                        type = "video";
                        break;
                    case "Audio":
                        type = "audio";
                        break;
                    case "Visual":
                        type = "visual";
                        break;
                }
                try
                {
                    await service.UploadNewFile(type, FileName, convertedForm);
                  
                    await Page.DisplayAlert("Yeah", "Your file has been uploaded", "OK");
                    SelectedOption = null;
                    FileName = null;
                    FilePath = null;

                }
                catch (Exception ex)
                {
                    Output = ex.ToString();
                }
           }
           else
           {
                FileName = "Please enter a file name";
           }

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
