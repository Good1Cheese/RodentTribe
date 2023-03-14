namespace RodentTribe.ViewModels;

public class AppViewModel : ViewModelBase
{
    public AppViewModel(ClosetViewModel closetsViewModel, BoxViewModel boxViewModel, RodentViewModel rodentViewModel)
    {
        ClosetViewModel = closetsViewModel;
        BoxViewModel = boxViewModel;
        RodentViewModel = rodentViewModel;
    }

    public ClosetViewModel ClosetViewModel { get; }
    public BoxViewModel BoxViewModel { get; }
    public RodentViewModel RodentViewModel { get; }
}
