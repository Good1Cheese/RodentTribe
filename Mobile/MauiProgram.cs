using RodentTribe.Data;
using RodentTribe.ViewModels;

namespace Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts();

        var services = builder.Services;

        services.AddSingleton<Database>();
        using (var provider = services.BuildServiceProvider())
        {
            SeedData.Initialize(provider);
        }

        services.AddSingleton<ClosetsViewModel>();
        services.AddSingleton<AppViewModel>();

        return builder.Build();
    }
}
