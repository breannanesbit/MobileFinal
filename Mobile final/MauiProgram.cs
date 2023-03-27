using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Mobile_final.ViewModels;
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
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddSingleton(c => new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5102/Media/")
        });

        builder.Services.AddSingleton<UploadFileViewModel>();
        builder.Services.AddSingleton<MainPage>();

        /*builder.Services.AddSingleton(new Auth0Client(new()
        {
            Domain = "dev-hpm6gkxhfq3nifhv.us.auth0.com",
            ClientId = "kXRZK1rKsIcu8ELWUhULepnbcqPwP2QT",
            Scope = "openid profile",
            RedirectUri = "myapp://callback"
        }));*/

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
