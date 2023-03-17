using RodentTribe.Data;
using RodentTribe.Data.Database;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Abstract;

namespace RodentTribe.ViewModels;

public class ClosetViewModel : SimpleViewModel<Сloset>
{
    public readonly string ViewTitle = "Выбор шкафа";

    public ClosetViewModel(Database database) 
        : base(database)
    {
    }

    public override void Select(object obj)
    {
        RodentOutput.Closet = (Сloset)obj;
        base.Select(obj);
    }

    protected override async Task MoveToNextView()
    {
        await Shell.Current.GoToAsync(nameof(BoxView));
    }
}
