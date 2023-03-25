using RodentTribe.Data;
using RodentTribe.Data.Databases;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Abstract;
using RodentTribe.ViewModels.Interfaces;
using RodentTribe.Views;
using System.Windows.Input;

namespace RodentTribe.ViewModels;

public class FreeFemalesViewModel : ViewModelBase<Rodent>, IAppearable
{
    public ICommand GoToRodentViewCommand { get; }

    public FreeFemalesViewModel(Database database)
        : base(database)
    {
        GoToRodentViewCommand = new Command(GoToRodentView);
    }

    protected override Task GetModels() => null;

    public async void OnAppearing()
    {
        var models = _database.Connection.Table<Rodent>();

        models = from m in models
                 where !m.IsMale
                 where m.WereChildbirth
                 where m.ChildbirthDate < DateTime.Today
                 select m;

        Models = new(await models.ToListAsync());
        OnPropertyChanged(nameof(Models));
    }

    private async void GoToRodentView()
    {
        await Shell.Current.GoToAsync(nameof(RodentView));
    }

    public override void Add() { }
    public override void Delete(object _) { }

    public override async void Select(object obj)
    {
        SelectedModels.Rodent = (Rodent)obj;
        await Shell.Current.GoToAsync(nameof(RodentEditView));
    }
}
