using RodentTribe.Views;

namespace RodentTribe.ViewModels;

public class AppViewModel
{
    public AppViewModel(ClosetViewModel closetsViewModel,
                        BoxViewModel boxViewModel,
                        RodentViewModel rodentViewModel,
                        RodentEditViewModel rodentEditViewModel, 
                        FreeFemalesViewModel freeFemalesViewModel)
    {
        ClosetViewModel = closetsViewModel;
        BoxViewModel = boxViewModel;
        RodentViewModel = rodentViewModel;
        RodentEditViewModel = rodentEditViewModel;
        FreeFemalesViewModel = freeFemalesViewModel;
    }

    public ClosetViewModel ClosetViewModel { get; }
    public BoxViewModel BoxViewModel { get; }
    public RodentViewModel RodentViewModel { get; }
    public RodentEditViewModel RodentEditViewModel { get; }
    public FreeFemalesViewModel FreeFemalesViewModel { get; }
}
