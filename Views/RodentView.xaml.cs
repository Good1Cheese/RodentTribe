using RodentTribe.ViewModels;

namespace RodentTribe.Views;

public partial class RodentView : ContentPage
{
	public RodentView()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        var rodentViewModel = (RodentViewModel)BindingContext;
        rodentViewModel.OnAppearing();
    }
}