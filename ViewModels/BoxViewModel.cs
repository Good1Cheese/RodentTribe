using RodentTribe.Data;
using RodentTribe.Data.Databases;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Abstract;
using RodentTribe.ViewModels.Interfaces;
using RodentTribe.Views;

namespace RodentTribe.ViewModels;

public class BoxViewModel : SimpleViewModel<Box>, IAppearable
{
    public string ViewTitle { get; } = "Выбор бокса";

    public BoxViewModel(Database database)
        : base(database)
    {
    }

    public async void OnAppearing()
    {
        var models = await _database.Connection.Table<Box>().ToListAsync();
        Models = new(models.Where(m => m.ClosetId == SelectedModels.Closet.Id));
        OnPropertyChanged(nameof(Models));
    }

    public override void Select(object obj)
    {
        SelectedModels.Box = (Box)obj;
        base.Select(obj);
    }

    protected override Task GetModels() => null;

    protected override async void GoToNextView()
    {
        await Shell.Current.GoToAsync(nameof(RodentView));
    }
}
