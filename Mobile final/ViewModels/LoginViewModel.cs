using CommunityToolkit.Mvvm.ComponentModel;
using Shared.Auth0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_final.ViewModels
{
    public class LoginViewModel 
    {
        private readonly Auth0Client auth0Client;

        public LoginViewModel(Auth0Client client)
        {
            auth0Client = client;    
        }

  

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var loginResult = await auth0Client.LoginAsync();

            if (!loginResult.IsError)
            {
                //LoginView.IsVisible = false;
                //HomeView.IsVisible = true;
            }
            else
            {
               // await DisplayAlert("Error", loginResult.ErrorDescription, "OK");
            }
        }
    }
}
