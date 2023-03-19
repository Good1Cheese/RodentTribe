using CommunityToolkit.Maui;
using RodentTribe.Data.Databases;
using RodentTribe.ViewModels;
using System;

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
        using (var provider = services.BuildServiceProvider())
        {
            SeedData.Initialize(provider);
        }

        services.AddSingleton<ClosetViewModel>();
        services.AddSingleton<BoxViewModel>();
        services.AddSingleton<RodentViewModel>();
        services.AddSingleton<RodentEditViewModel>();
        services.AddSingleton<AppViewModel>();

        return builder.Build();
    }
}
