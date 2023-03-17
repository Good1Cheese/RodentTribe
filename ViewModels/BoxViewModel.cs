using RodentTribe.Data;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Abstract;
using RodentTribe.Views;

namespace RodentTribe.ViewModels;

public class BoxViewModel : SimpleViewModel<Box>
{
    public BoxViewModel(Database database)
        : base(database)
    {
    }

    protected override async Task MoveToNextView()
    {
        await Shell.Current.GoToAsync(nameof(RodentView));
    }
}