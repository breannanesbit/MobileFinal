using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Mobile_final.ViewModels;
using Mobile_final.Auth0;
using Syncfusion.Maui.Core.Hosting;
using Mobile_final.Pages;
using Mobile_final.Services;
//using Mobile_final.Auth0;

namespace Mobile_final;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
             .UseMauiCommunityToolkitMediaElement()
             .ConfigureSyncfusionCore()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddSingleton(c => new HttpClient()
        {
            BaseAddress = new Uri("https://multimediaapi.azurewebsites.net")
        });

        builder.Services.AddSingleton<UploadFileViewModel>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<UploadPage>();
        builder.Services.AddSingleton<ProfilePage>();
        builder.Services.AddSingleton<SchedulePage>();
        builder.Services.AddSingleton<HomeMediaPage>();
        builder.Services.AddSingleton<ProfileViewModel>();
        builder.Services.AddSingleton<ScheduleViewModel>();
        builder.Services.AddSingleton<ProfileViewModel>();
        builder.Services.AddSingleton<HomeMediaViewModel>();
        builder.Services.AddSingleton<UserService>();


        builder.Services.AddSingleton(new Auth0Client(new()
        {
            Domain = "dev-hpm6gkxhfq3nifhv.us.auth0.com",
            ClientId = "kXRZK1rKsIcu8ELWUhULepnbcqPwP2QT",
            Scope = "openid profile",
            RedirectUri = "myapp://callback"
        }));

#if DEBUG
        builder.Logging.AddDebug();
#endif
        //Routing.RegisterRoute(nameof(UploadPage), typeof(UploadPage));  

        return builder.Build();
    }
}
