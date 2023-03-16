using Android.Widget;
using RodentTribe.Data;
using RodentTribe.Data.Models;

namespace RodentTribe.ViewModels;

public class ClosetViewModel : SimpleViewModel<Сloset>
{
    public ClosetViewModel(Database database) 
        : base(database)
    {
    }

    protected override async Task MoveToNextView()
    {
        await Shell.Current.GoToAsync(nameof(BoxView));
    }
}
