using RodentTribe.Data;
using RodentTribe.Data.Databases;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Abstract;

namespace RodentTribe.ViewModels;

public class ClosetViewModel : SimpleViewModel<Сloset>
{
    public string ViewTitle { get; } = "Выбор шкафа";

    public ClosetViewModel(Database database) 
        : base(database)
    {
    }

    public override void Select(object obj)
    {
        SelectedModels.Closet = (Сloset)obj;
        base.Select(obj);
    }

    protected override async void GoToNextView()
    {
        await Shell.Current.GoToAsync(nameof(BoxView));
    }
}
