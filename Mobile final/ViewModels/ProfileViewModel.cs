using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Services;
using Shared;
using System;
using System.Collections.Generic;
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

        public ProfileViewModel(HttpClient cli)
        {
            this.client = cli;
        }
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private List<Media> video;

        [ObservableProperty]
        private IEnumerable<Media> visual;
        public ProfileViewModel(UserService service)
        {
            this.service = service;
        }
        [ObservableProperty]
        private string firstName;

        [RelayCommand]
        public async Task GetIt()
        {
           var userList =  await service.GetAllUsers();
           FirstName = userList[0].FirstName;
        }


        [RelayCommand]
        public async Task Start()
        {
           /* var response = await client.GetAsync($"getusermedia/{Username}");
            var list = await response.Content.ReadFromJsonAsync<List<Media>>();
            foreach ( var item in list)
            {
                var medcat = item.MediaCategories;
                foreach( var item2 in medcat)
                {
                    if(item2.Category.Category1 == "Videos")
                    {
                        Video.Add(item);
                    }
                }
            }*/
        }
    }
}