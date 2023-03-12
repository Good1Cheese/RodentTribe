namespace RodentTribe.Views;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ClosetSelectView), typeof(ClosetSelectView));
        Routing.RegisterRoute(nameof(BoxSelectView), typeof(BoxSelectView));
    }
}
