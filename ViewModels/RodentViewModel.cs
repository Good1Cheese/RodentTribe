using AndroidX.AppCompat.View.Menu;
using RodentTribe.Data;
using RodentTribe.Data.Databases;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Abstract;
using RodentTribe.Views;

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
                 where m.ClosetId == SelectedModels.Closet.Id
                 where m.BoxId == SelectedModels.Box.Id
                 select m;

        Models = new(await models.ToListAsync());
        OnPropertyChanged(nameof(Models));
    }

    protected override Task GetModels() => null;

    public override async void Add()
    {
        var rodent = new Rodent 
        {
            Category = AgeCategory.Categories.Germ,
            IsMale = false,
            IsPregnant = false,
            Hallmarks = "отсутствуют",
            BirthDay = DateTime.Today,
            ClosetId = SelectedModels.Closet.Id,
            BoxId = SelectedModels.Box.Id
        };

        await _database.Connection.InsertAsync(rodent);
        Models.Add(rodent);
    }

    public override async void Delete(object obj)
    {
        await _database.Connection.DeleteAsync(obj);
        Models.Remove((Rodent)obj);
    }

    public override async void Select(object obj)
    {
        SelectedModels.Rodent = (Rodent)obj;
        await Shell.Current.GoToAsync(nameof(RodentEditView));
    }
}
