

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Services;
using Shared;
using System.Collections.ObjectModel;
using static System.Net.WebRequestMethods;

namespace Mobile_final.ViewModels
{
    public partial class HomeMediaViewModel : ObservableObject
    {
        public ObservableCollection<Media> VideoList { get; set; } = new();
        public ObservableCollection<Media> AudioList { get; set; } = new();
        public ObservableCollection<Media> VisualList { get; set; } = new();
        private readonly UserService service;

        public HomeMediaViewModel(UserService service)
        {
            this.service = service;
        }

        [ObservableProperty]
        private string comment;

        [RelayCommand]
        public async Task Start()//Possible testing opportunity, mock out the API results
        {
            var latestMediaList = await service.GetMostRecentUploaded();
            var userList = await service.GetAllUsers();
            foreach (var media in latestMediaList)
            {
                media.User = userList.Find(m => m.Id == media.UserId);
                if (media.Category.Category1 == "Videos")
                {
                    media.MediaKey = "https://mobilemediastorage.blob.core.windows.net/videos/" + media.MediaKey;
                    //media.UserName = media.User.Username;
                    VideoList.Add(media);
                }
                else if (media.Category.Category1 == "Audios")
                {
                    media.MediaKey = "https://mobilemediastorage.blob.core.windows.net/audios/" + media.MediaKey;
                    //media.UserName = media.User.Username;
                    AudioList.Add(media);
               
                }
                else if (media.Category.Category1 == "Pictures")
                {
                    media.MediaKey = "https://mobilemediastorage.blob.core.windows.net/pictures/" + media.MediaKey;
                    //media.UserName = media.User.Username;
                    VisualList.Add(media);
                }
            }
        }


        [RelayCommand]
        public async void SubmitComment(Media media)
        {
            await service.SubmitComment(media.Id, Comment);
            Comment = null;
        }
    }
}
