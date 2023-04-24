using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Pages;
using Mobile_final.Services;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_final.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        private readonly HttpClient client;
        private readonly UserService service;
        private readonly INavigationService nav;
        public ProfileViewModel(HttpClient cli, UserService service, INavigationService nav)
        {
            this.client = cli;
            this.service = service;
            this.nav = nav;
        }

        public ObservableCollection<Media> PersonsMedia { get; set; } = new();

        [ObservableProperty]
        private string userName;

        //[ObservableProperty]
        //private List<Media> video;

        [ObservableProperty]
        private IEnumerable<Media> visual;

        [ObservableProperty]
        private string firstName;
        [ObservableProperty]
        private string lastName;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string noMedia;

        [RelayCommand]
        public async Task GetUser()
        {
            var userList = await service.GetCurrentUser();
            FirstName = userList.FirstName;
            LastName = userList.LastName;
            UserName = userList.Username;
            Name = $"{FirstName} {LastName}";
        }


        [RelayCommand]
        public async Task Start()
        {
            GetUser();
            var mediaList = await service.GetUserMedia();
            /*var response = await client.GetAsync($"getusermedia/{Username}");
             var list = await response.Content.ReadFromJsonAsync<List<Media>>();*/

            if (mediaList.Count != 0)
            {
                foreach (var item in mediaList)
                {
                    /*var medcat = item.MediaCategories;
                    foreach( var item2 in medcat)
                    {
                        if(item2.Category.Category1 == "Visual")
                        {
                        }
                    }*/
                    PersonsMedia.Add(item);
                }

            }
            else
            {
                NoMedia = "You have not uploaded anything";
            }
        }

        [RelayCommand]
        public async Task NavToPlayer(string mediaKey)
        {
        
            Media media = await service.GetMediaByKey(mediaKey);

            switch (media.CategoryId)
            {
                case 1:
                    media.MediaKey = "https://mobilemediastorage.blob.core.windows.net/videos/" + media.MediaKey;
                    break;
                case 2:
                    media.MediaKey = "https://mobilemediastorage.blob.core.windows.net/audios/" + media.MediaKey;
                    break;
                case 3:
                    media.MediaKey = "https://mobilemediastorage.blob.core.windows.net/pictures/" + media.MediaKey;
                    break;
                default:
                    // Handle unexpected category
                    break;
            }
            await nav.NaviagteToAsync($"{nameof(PlayMediaPage)}?mediaKey={media.MediaKey}&id={media.Id}");
            //nav to play page
            //attach as parameter the media object
        }
    }
}