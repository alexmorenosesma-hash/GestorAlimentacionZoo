using Client.Pagemodel.Inventarios;
using Client.Pagemodel.Login;
using Client.Pagemodel.Menu;
using Client.Pagemodel.Popups;
using Client.Pages.Login;
using Client.Popups;
using CommunityToolkit.Maui;
using Infraestructure;
using MauiIcons.Fluent;
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
                .UseFluentMauiIcons()
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
            builder.Services.AddTransient<MenuPagemodel>();
            builder.Services.AddTransient<EspeciePagemodel>();
            builder.Services.AddTransientPopup<EspeciePopup, EspeciePopupPagemodel>();
            builder.Services.AddTransientPopup<EspecieModificarPopup, EspecieModificarPopupPagemodel>();
            builder.Services.AddTransientPopup<EliminarPopup, EliminarPopupPagemodel>();
            return builder;
        }
    }
}
