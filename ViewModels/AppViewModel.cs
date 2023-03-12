namespace RodentTribe.ViewModels;

public class AppViewModel : ViewModelBase
{
    public AppViewModel(ClosetViewModel closetsViewModel, BoxViewModel boxViewModel)
    {
        ClosetViewModel = closetsViewModel;
        BoxViewModel = boxViewModel;
    }

    public ClosetViewModel ClosetViewModel { get; }
    public BoxViewModel BoxViewModel { get; }
}
