using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Services;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_final.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        private readonly UserService service;
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
    }
}
