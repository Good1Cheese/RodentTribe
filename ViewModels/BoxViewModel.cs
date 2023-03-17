using RodentTribe.Data;
using RodentTribe.Data.Database;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Abstract;
using RodentTribe.Views;

namespace RodentTribe.ViewModels;

public class BoxViewModel : SimpleViewModel<Box>
{
    public readonly string ViewTitle = "Выбор бокса";

    public BoxViewModel(Database database)
        : base(database)
    {
    }

    public override void Select(object obj)
    {
        RodentOutput.Box = (Box)obj;
        base.Select(obj);
    }

    protected override async Task MoveToNextView()
    {
        await Shell.Current.GoToAsync(nameof(RodentView));
    }
}