using RodentTribe.ViewModels;
using RodentTribe.Views.Shared;

namespace RodentTribe.Views;

public partial class RodentEditView : PageWithAppearableViewModel
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
