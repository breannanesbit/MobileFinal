using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Auth0;

namespace Mobile_final.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly Auth0Client auth0Client;

        public LoginViewModel(Auth0Client client)
        {
            auth0Client = client; 
        }

        [ObservableProperty]
        private bool loginView;

        [ObservableProperty]
        private bool homeView;

        [RelayCommand]
        private async void OnLoginClicked()
        {
            var loginResult = await auth0Client.LoginAsync();

            if (!loginResult.IsError)
            {
                LoginView = false;
                HomeView = true;
            }
            else
            {
               Console.WriteLine("Error", loginResult.ErrorDescription, "OK");
            }
        }
    }
}
