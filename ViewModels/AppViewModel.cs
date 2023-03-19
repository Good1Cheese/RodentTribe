namespace RodentTribe.ViewModels;

public class AppViewModel
{
    public AppViewModel(ClosetViewModel closetsViewModel,
                        BoxViewModel boxViewModel,
                        RodentViewModel rodentViewModel,
                        RodentEditViewModel rodentEditViewModel)
    {
        ClosetViewModel = closetsViewModel;
        BoxViewModel = boxViewModel;
        RodentViewModel = rodentViewModel;
        RodentEditViewModel = rodentEditViewModel;
    }

    public ClosetViewModel ClosetViewModel { get; }
    public BoxViewModel BoxViewModel { get; }
    public RodentViewModel RodentViewModel { get; }
    public RodentEditViewModel RodentEditViewModel { get; }
}
