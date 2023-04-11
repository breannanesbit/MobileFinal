using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        public ProfileViewModel(HttpClient cli, UserService service)
        {
            this.client = cli;
            this.service = service;
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

        [RelayCommand]
        public async Task GetUser()
        {
            var userList =  await service.GetCurrentUser();
            FirstName = userList.FirstName;
            LastName = userList.LastName;
            UserName = userList.Username;
        }


        [RelayCommand]
        public async Task Start()
        {
            GetUser();
            /*var response = await client.GetAsync($"getusermedia/{Username}");
             var list = await response.Content.ReadFromJsonAsync<List<Media>>();*/
            var list = await service.GetUserMedia();
            foreach ( var item in list)
            {
                var medcat = item.MediaCategories;
                foreach( var item2 in medcat)
                {
                    if(item2.Category.Category1 == "Videos")
                    {
                        PersonsMedia.Add(item);
                    }
                }
            }
        }
    }
}