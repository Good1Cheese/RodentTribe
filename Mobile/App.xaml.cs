using RodentTribe.Views;
using RodentTribe.ViewModels;

namespace Mobile;

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
