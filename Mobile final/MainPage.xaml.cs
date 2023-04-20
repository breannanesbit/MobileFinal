using Mobile_final.Auth0;
using Mobile_final.ViewModels;

namespace Mobile_final;


public partial class MainPage : ContentPage
{
    private readonly Auth0Client auth0Client;
    public MainPage(LoginViewModel model, Auth0Client client)
    {
        InitializeComponent();
        BindingContext = model;
        auth0Client= client;

#if WINDOWS
    auth0Client.Browser = new WebViewBrowserAuthenticator(WebViewInstance);
     //model.Login();
#endif
    }

    public async Task IfWindows(LoginViewModel model, Auth0Client auth0Client)
    {

        var loginResult = await auth0Client.LoginAsync();
        model.currentUser.Username = loginResult.User.Identity.Name;
        model.currentUser.AuthenticationID = loginResult.AccessToken;
    }

}
