using RodentTribe.ViewModels;
using RodentTribe.Views;

namespace RodentTribe;

public partial class App : Application
{
	public App(AppViewModel appViewModel)
	{
		InitializeComponent();

        MainPage = new AppShell
        {
            BindingContext = appViewModel
        };
    }
}
