using RodentTribe.ViewModels.Interfaces;

namespace RodentTribe.Views.Shared;

public class PageWithAppearableViewModel : ContentPage
{
    protected override void OnAppearing()
    {
        base.OnAppearing();

        var viewModel = (IAppearable)BindingContext;
        viewModel.OnAppearing();
    }
}
