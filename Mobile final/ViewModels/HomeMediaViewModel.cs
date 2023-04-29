
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Services;
using MobileFinal.ViewModels;
using Shared;
using System.Collections.ObjectModel;

namespace Mobile_final.ViewModels
{
    public partial class HomeMediaViewModel : ObservableObject
    {
        public ObservableCollection<MediaDisplayOutLine> VideoList { get; set; } = new();
        public ObservableCollection<MediaDisplayOutLine> AudioList { get; set; } = new();
        public ObservableCollection<MediaDisplayOutLine> VisualList { get; set; } = new();
        private readonly IUserService service;

        public HomeMediaViewModel(IUserService service)
        {
            this.service = service;
        }

        [ObservableProperty]
        private string comment;

        [RelayCommand]
        public async Task Start()
        {
            VideoList.Clear();
            AudioList.Clear();
            VisualList.Clear();

            var latestMediaList = await service.GetMostRecentUploaded();
            var userList = await service.GetAllUsers();
            SortMediaIntoLists(latestMediaList, userList, VideoList, AudioList, VisualList);
        }

        public void SortMediaIntoLists(List<Media> latestMediaList, List<User> userList, ObservableCollection<MediaDisplayOutLine> videoList, ObservableCollection<MediaDisplayOutLine> audioList, ObservableCollection<MediaDisplayOutLine> visualList)
        {
            foreach (var media in latestMediaList)
            {
                media.User = userList.Find(m => m.Id == media.UserId);
                if (media.CategoryId == 1 || media.Category.Category1 == "Videos")
                {
                    media.MediaKey = "https://mobilemediastorage.blob.core.windows.net/videos/" + media.MediaKey;
                    //media.UserName = media.User.Username;
                    var md = new MediaDisplayOutLine
                    {
                        MediaItem = media,
                        Comment = null,
                        LikeSelected = false,
                    };
                    videoList.Add(md);
                }
                else if (media.CategoryId == 2 || media.Category.Category1 == "Audios")
                {
                    media.MediaKey = "https://mobilemediastorage.blob.core.windows.net/audios/" + media.MediaKey;
                    //media.UserName = media.User.Username;
                    var md = new MediaDisplayOutLine
                    {
                        MediaItem = media,
                        Comment = null,
                        LikeSelected = false,
                    };
                    audioList.Add(md);

                }
                else if (media.CategoryId == 3 || media.Category.Category1 == "Pictures")
                {
                    media.MediaKey = "https://mobilemediastorage.blob.core.windows.net/pictures/" + media.MediaKey;
                    //media.UserName = media.User.Username;
                    var md = new MediaDisplayOutLine
                    {
                        MediaItem = media,
                        Comment = null,
                        LikeSelected = false,
                    };
                    visualList.Add(md); ;
                } 
            }
        }

        [RelayCommand]
        public async void SubmitComment(MediaDisplayOutLine mediaItem)
        {
            await service.SubmitComment(mediaItem.MediaItem.Id, mediaItem.Comment);
            mediaItem.Comment = null;
        }

        [RelayCommand]
        public async void SubmitLike(MediaDisplayOutLine media)
        {
            media.LikeSelected = !media.LikeSelected;
            await service.SubmitLike(media.MediaItem, media.LikeSelected);
            

        }
    }
}
