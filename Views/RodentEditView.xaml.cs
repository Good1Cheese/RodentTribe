using RodentTribe.ViewModels;

namespace RodentTribe.Views;

public partial class RodentEditView : ContentPage
{
	public RodentEditView()
	{
		InitializeComponent();
	}

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        var viewModel = (RodentEditViewModel)BindingContext;
        viewModel.OnDisappearing();
    }
}
