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
    public partial class HomeMediaViewModel : ObservableObject
    {

        [ObservableProperty]
        private string url;


        [RelayCommand]
        public void Start()
        {
            Url = "665e813e-7e0b-45fb-9ddd-260716909c56";

        }
    }
}
