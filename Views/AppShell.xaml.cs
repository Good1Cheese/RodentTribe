namespace RodentTribe.Views;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ClosetView), typeof(ClosetView));
        Routing.RegisterRoute(nameof(BoxView), typeof(BoxView));
        Routing.RegisterRoute(nameof(RodentView), typeof(RodentView));
    }
}
