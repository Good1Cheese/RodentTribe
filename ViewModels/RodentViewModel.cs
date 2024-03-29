﻿using RodentTribe.Data;
using RodentTribe.Data.Databases;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Abstract;
using RodentTribe.ViewModels.Interfaces;
using RodentTribe.Views;
using System.Windows.Input;

namespace RodentTribe.ViewModels;

public class RodentViewModel : ViewModelBase<Rodent>, IAppearable
{
    public ICommand GoToFreeFemalesCommand { get; set; }
    public ICommand GoToClosetViewCommand { get; set; }
    public ICommand GoToBoxViewCommand { get; set; }

    public RodentViewModel(Database database)
        : base(database)
    {
        GoToFreeFemalesCommand = new Command(GoToFreeFemales);
        GoToClosetViewCommand = new Command(GoToClosetViewAsync);
        GoToBoxViewCommand = new Command(GoToBoxView);
    }


    protected override Task GetModels() => null;

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

    private async void GoToFreeFemales() => await Shell.Current.GoToAsync(nameof(FreeFemalesView));
    private async void GoToClosetViewAsync() => await Shell.Current.GoToAsync(nameof(ClosetView));
    private async void GoToBoxView() => await Shell.Current.GoToAsync(nameof(Views.BoxView));

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
