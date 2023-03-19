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
        base.OnAppearing();

        var viewModel = (RodentViewModel)BindingContext;
        viewModel.OnAppearing();
    }
}