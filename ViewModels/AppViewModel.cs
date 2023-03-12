namespace RodentTribe.ViewModels;

public class AppViewModel : ViewModelBase
{
    public AppViewModel(ClosetsViewModel closetsViewModel)
    {
        ClosetsViewModel = closetsViewModel;
    }

    public ClosetsViewModel ClosetsViewModel { get; }
}