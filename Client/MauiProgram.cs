using Client.Pagemodel.Login;
using Client.Pages.Login;
using CommunityToolkit.Maui;
using Infraestructure;
using Microsoft.Extensions.Logging;

namespace Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddInfraestructure();
            builder.dependencias();
            return builder.Build();
        }
        public static MauiAppBuilder dependencias(this MauiAppBuilder builder)
        {
            builder.Services.AddScoped<LoginPage>();
            builder.Services.AddScoped<LoginPagemodel>();
            return builder;
        }
    }
}
