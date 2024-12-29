using Microsoft.Extensions.Logging;
using PlantiaApp.Services;
using PlantiaApp.Shared.Services;
using PlantiaApp.Shared.Core.Contexts;
using PlantiaApp.Shared.Components.Authorization.Services;

namespace PlantiaApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services used by the PlantiaApp.Shared project
            //builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddSingleton<SQLiteContexts>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
