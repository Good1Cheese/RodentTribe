using RodentTribe.Data;
using RodentTribe.Data.Databases;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Abstract;
using RodentTribe.Views;

namespace RodentTribe.ViewModels;

public class BoxViewModel : SimpleViewModel<Box>
{
    public string ViewTitle { get; } = "Выбор бокса";

    public BoxViewModel(Database database)
        : base(database)
    {
    }

    public override void Select(object obj)
    {
        SelectedModels.Box = (Box)obj;
        base.Select(obj);
    }

    protected override async void GoToNextView()
    {
        await Shell.Current.GoToAsync(nameof(RodentView));
    }
}
