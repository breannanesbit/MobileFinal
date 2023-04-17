

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Services;
using Shared;
using System.Collections.ObjectModel;

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

        [RelayCommand]
        public async Task Start()
        {
            var latestMediaList = await service.GetMostRecentUploaded();
            foreach (var media in latestMediaList)
            {
                if (media.Category.Category1 == "Videos")
                {
                    VideoList.Add(media);
                }
                else if (media.Category.Category1 == "Audios")
                {
                    AudioList.Add(media);
                }
                else if (media.Category.Category1 == "Pictures")
                {
                    VisualList.Add(media);
                }
            }
        }
    }
}
