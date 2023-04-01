using CommunityToolkit.Maui;
using RodentTribe.Data.Databases;
using RodentTribe.ViewModels;

namespace RodentTribe;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts();

        var services = builder.Services;

        services.AddSingleton<Database>();

#if DEBUG
        using (var provider = services.BuildServiceProvider())
        {
            SeedData.Initialize(provider);
        }
#endif

        services.AddSingleton<ClosetViewModel>();
        services.AddSingleton<BoxViewModel>();
        services.AddSingleton<RodentViewModel>();
        services.AddSingleton<FreeFemalesViewModel>();
        services.AddSingleton<RodentEditViewModel>();
        services.AddSingleton<AppViewModel>();

        return builder.Build();
    }
}
