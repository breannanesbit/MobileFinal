using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Mobile_final.ViewModels;
using Mobile_final.Auth0;
using Syncfusion.Maui.Core.Hosting;
using Mobile_final.Pages;
using Mobile_final.Services;
using Microsoft.Extensions.Configuration;
using System.Reflection;
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

        builder.Services.AddHttpClient("v1", c =>
        {
            c.BaseAddress = new Uri("https://multimediaapi.azurewebsites.net");
            c.DefaultRequestHeaders.Add("version", "1.0");
        }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler());
        //.AddHttpMessageHandler<TokenHandler>();

        builder.Services.AddHttpClient("v2", c =>
        {
            c.BaseAddress = new Uri("https://multimediaapi.azurewebsites.net");
            c.DefaultRequestHeaders.Add("version", "2.0");
        }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler());
       //.AddHttpMessageHandler<TokenHandler>();

        builder.Services.AddSingleton<UserService>(provider =>
        {
            var clientV1 = provider.GetRequiredService<IHttpClientFactory>().CreateClient("v1");
            var clientV2 = provider.GetRequiredService<IHttpClientFactory>().CreateClient("v2");

            return new UserService(clientV1, clientV2);

        });

        /*builder.Services.AddTransient(
            sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api")
        );

        /*builder.Services.AddSingleton(c =>
        {
            var config = c.GetRequiredService<IConfiguration>();
            return new HttpClient()
            {
                //BaseAddress = new Uri(config["ApiAddress"])
                BaseAddress = new Uri("https://multimediaapi.azurewebsites.net/")
            };
        });*/


        /*var a = Assembly.GetExecutingAssembly();
        var m = a.Modules;
        var names = a.GetManifestResourceNames();
        using var stream = a.GetManifestResourceStream("Mobile_final.appsettings.json");
        var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
        builder.Configuration.AddConfiguration(config);*/

        //builder.Services.AddSingleton(c => new HttpClient()
        //{ 
        //    BaseAddress = new Uri("https://localhost:5210")
        //});


        builder.Services.AddSingleton<UploadFileViewModel>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<UploadPage>();
        builder.Services.AddSingleton<ProfilePage>();
        builder.Services.AddSingleton<SchedulePage>();
        builder.Services.AddSingleton<PlayMediaPage>();
        builder.Services.AddSingleton<HomeMediaPage>();
        builder.Services.AddSingleton<ProfileViewModel>();
        builder.Services.AddSingleton<ScheduleViewModel>();
        builder.Services.AddSingleton<ProfileViewModel>();
        builder.Services.AddSingleton<HomeMediaViewModel>();
        builder.Services.AddSingleton<PlayMediaViewModel>();
        //builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<UploadService>();
        builder.Services.AddSingleton<AppointmentService>();
        builder.Services.AddSingleton<CurrentUser>();


        builder.Services.AddSingleton(new Auth0Client(new()
        {
            Domain = "dev-hpm6gkxhfq3nifhv.us.auth0.com",
            ClientId = "kXRZK1rKsIcu8ELWUhULepnbcqPwP2QT",
            Scope = "openid profile email",
#if WINDOWS
            RedirectUri = "http://localhost/callback"
#else
            RedirectUri = "myapp://callback"
#endif
        }));

#if DEBUG
        builder.Logging.AddDebug();
#endif
        Routing.RegisterRoute(nameof(PlayMediaPage), typeof(PlayMediaPage));
        Routing.RegisterRoute(nameof(HomeMediaPage), typeof(HomeMediaPage));

        return builder.Build();
    }
}
