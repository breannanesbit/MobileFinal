

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Services;
using Shared;
using System.Collections.ObjectModel;

namespace Mobile_final.ViewModels
{
    public partial class HomeMediaViewModel : ObservableObject
    {
        ObservableCollection<Media> videoList = new();
        ObservableCollection<Media> audioList = new();
        ObservableCollection<Media> visualList = new();
        private readonly UserService service;

        public HomeMediaViewModel(UserService service)
        {
            this.service = service;
        }

        [RelayCommand]
        public async Task Start()
        {
            var latestMediaList = await service.GetMostRecentUploaded();
            foreach (var media in latestMediaList)
            {
                if (media.Category.Category1 == "Videos")
                {
                    videoList.Add(media);
                }
                else if (media.Category.Category1 == "Audios")
                {
                    audioList.Add(media);
                }
                else if (media.Category.Category1 == "Pictures")
                {
                    visualList.Add(media);
                }
            }
        }
    }
}
