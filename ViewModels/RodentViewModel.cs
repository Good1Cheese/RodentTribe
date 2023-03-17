using RodentTribe.Data;
using RodentTribe.Data.Database;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Abstract;

namespace RodentTribe.ViewModels;

public class RodentViewModel : ViewModelBase<Rodent>
{
    public RodentViewModel(Database database)
        : base(database)
    {

    }

    public async void OnAppearing()
    {
        var models = _database.Connection.Table<Rodent>();

        models = from m in models
                 where m.ClosetId == RodentOutput.Closet.Id
                 where m.BoxId == RodentOutput.Box.Id
                 select m;

        Models = new(await models.ToListAsync());
        OnPropertyChanged(nameof(Models));
    }

    protected override Task GetModels() => null;

    public override async void Add(object obj)
    {
        // Create and go to edit view
    }

    public override async void Delete(object obj)
    {
        await _database.Connection.DeleteAsync(obj);
        Models.Remove((Rodent)obj);
    }

    public override async void Select(object obj)
    {
        // Go to edit view
    }
}
