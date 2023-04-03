using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Auth0;
using Mobile_final.Pages;
//using Mobile_final.Auth0;
//using Shared.Auth0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_final.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly Auth0Client auth0Client;
        private readonly INavigationService nag;

        public LoginViewModel(Auth0Client client, INavigationService nag)
        {
            auth0Client = client;
            this.nag = nag;
            LoginView = true;
            SignUpView = false;
        }

        [ObservableProperty]
        private bool loginView;

        [ObservableProperty]
        private bool signUpView;

        [RelayCommand]
        public void SignUpViewToShowUp() => SignUpView = true;

        [RelayCommand]
        public void AddUserToDatabase()
        {
            //Create new user in database with their information
        }

        [RelayCommand]
        public async Task Login()
        {
            /*var loginResult = await auth0Client.LoginAsync();

             if (!loginResult.IsError)
             {
                 LoginView = false;
             }
             else
             {
                 Console.WriteLine("Error", loginResult.ErrorDescription, "OK");
             }*/
            Application.Current.MainPage = new AppShell();
            //NavigateToUpload(nameof(UploadPage));
        }


        public async void NavigateToUpload(string destination)
        {
            await nag.NaviagteToAsync(destination);

        }
    }
}
