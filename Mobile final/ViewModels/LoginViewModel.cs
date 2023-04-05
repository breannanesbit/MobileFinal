﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Auth0;
using Mobile_final.Pages;
using Mobile_final.Services;
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
        private readonly UserService service;

        public LoginViewModel(Auth0Client client, INavigationService nag, UserService service)
        {
            auth0Client = client;
            this.nag = nag;
            this.service = service;
            LoginView = true;
            SignUpView = false;
        }

        [ObservableProperty]
        private bool loginView;
        [ObservableProperty]
        private bool signUpView;
        [ObservableProperty]
        private string firstName;
        [ObservableProperty]
        private string lastName;

        [RelayCommand]
        public void SignUpViewToShowUp() => SignUpView = true;

        [RelayCommand]
        public async Task AddUserToDatabase(string username)
        {
            await service.NewUserEntry(FirstName, LastName, username);
        }

        [RelayCommand]
        public async Task Login()
        {
            if(Device.RuntimePlatform == Device.Android)
            {
                var loginResult = await auth0Client.LoginAsync();

             if (!loginResult.IsError)
             {
                 LoginView = false;
             }
             else
             {
                 Console.WriteLine("Error", loginResult.ErrorDescription, "OK");
             }

             if(FirstName != null && LastName != null)
             {
                await AddUserToDatabase(loginResult.User.Identity.Name);

             }

            Application.Current.MainPage = new AppShell();
            //NavigateToUpload(nameof(UploadPage));
        }




        public async void NavigateToUpload(string destination)
        {
            await nag.NaviagteToAsync(destination);

        }
    }
}
