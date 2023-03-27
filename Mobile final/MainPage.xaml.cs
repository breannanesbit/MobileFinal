using Mobile_final.Auth0;
using Mobile_final.ViewModels;

namespace Mobile_final;


public partial class MainPage : ContentPage
{
    int count = 0;
    // 👇 new code
    private readonly Auth0Client auth0Client;
    // 👆 new code

    public MainPage(Auth0Client client/*, LoginViewModel model*/)
    // 👆 changed code
    {
        InitializeComponent();
        //BindingContext = model;
        auth0Client = client;    // 👈 new code
    }

    //...existing code...

    // 👇 new code
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var loginResult = await auth0Client.LoginAsync();

        if (!loginResult.IsError)
        {
            LoginView.IsVisible = false;
            HomeView.IsVisible = true;
        }
        else
        {
            await DisplayAlert("Error", loginResult.ErrorDescription, "OK");
        }
    }
    // 👆 new code

}
    