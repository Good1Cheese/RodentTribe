﻿using CommunityToolkit.Maui.Alerts;
using RodentTribe.Data;
using RodentTribe.Data.Converters;
using RodentTribe.Data.Databases;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Interfaces;
using RodentTribe.Views;
using System.Reflection;
using System.Windows.Input;

namespace RodentTribe.ViewModels;

public class RodentEditViewModel : NotifyPropertyChanged, IAppearable
{
    public const string CANCEL = "Отмена";

    private readonly Database _database;

    public List<Сloset> Closets { get; set; }
    public List<Box> Boxes { get; set; }

    public Сloset SelectedCloset { get; set; }
    public Box SelectedBox { get; set; }

    public ICommand EditAgeCategoryCommand { get; }
    public ICommand EditTypeCommand { get; }
    public ICommand EditGenderCommand { get; }
    public ICommand EditPregnantStatusCommand { get; }
    public ICommand EditHallmarksCommand { get; }
    public ICommand EditBirthDayCommand { get; }
    public ICommand RestAfterChildbirthCommand { get; }
    public ICommand CancelRestAfterChildbirthCommand { get; }
    public ICommand MoveRodentToNewClosetAndBoxCommand { get; }
    public ICommand GoToRodentViewCommand { get; }
    public bool IsChanged { get; set; }

    public RodentEditViewModel(Database database)
    {
        _database = database;

        EditAgeCategoryCommand = new Command(EditAgeCategory);
        EditAgeCategoryCommand = new Command(EditType);
        EditGenderCommand = new Command(EditGender);
        EditPregnantStatusCommand = new Command(EditPregnantStatus);
        EditHallmarksCommand = new Command(EditHallmarks);
        EditBirthDayCommand = new Command(EditBirthDay);
        EditBirthDayCommand = new Command(EditBirthDay);
        RestAfterChildbirthCommand = new Command(RestAfterChildbirth);
        CancelRestAfterChildbirthCommand = new Command(CancelRestAfterChildbirth);
        MoveRodentToNewClosetAndBoxCommand = new Command(MoveRodentToNewClosetAndBox);
        GoToRodentViewCommand = new Command(GoToRodentView);
    }

    public async void OnAppearing()
    {
        var closets = _database.Connection.Table<Сloset>();
        Closets = new(await closets.ToListAsync());
        OnPropertyChanged(nameof(Closets));

        var boxes = _database.Connection.Table<Box>();
        Boxes = new(await boxes.ToListAsync());
        OnPropertyChanged(nameof(Boxes));
    }

    public async void OnDisappearing()
    {
        if (IsChanged)
        {
            IsChanged = false;
            await Shell.Current.DisplaySnackbar("Изменения успешно сохранены");
        }

        _database.Connection.UpdateAsync(SelectedModels.Rodent);
    }

    private async void EditAgeCategory()
    {
        var categoryName = await Shell.Current.DisplayActionSheet("Выбор возрастной категори", CANCEL, null, AgeCategory.Names);
        var category = AgeCategory.GetCategoryByName(categoryName);

        if ((int)category == -1) return;

        SelectedModels.Rodent.Category = category;
        IsChanged = true;
    }

    private async void EditType()
    {
        var categoryName = await Shell.Current.DisplayActionSheet("Выбор возрастной категори", CANCEL, null, Rodents.Names);
        var type = Rodents.GetTypeByName(categoryName);

        if ((int)type == -1) return;

        SelectedModels.Rodent.Type = type;
        IsChanged = true;
    }

    private async void EditGender()
    {
        var gender = await Shell.Current.DisplayActionSheet("Выбор пола", CANCEL, null, Rodent.MALE, Rodent.FEMALE);

        if (gender == CANCEL) return;

        SelectedModels.Rodent.IsMale = gender == Rodent.MALE;
        IsChanged = true;
    }

    private async void EditPregnantStatus()
    {
        var isPregnant = await Shell.Current.DisplayActionSheet("Изменение беременности", CANCEL, null, YesOrNoConverter.POSITIV, YesOrNoConverter.NEGATIV);

        if (isPregnant == CANCEL) return;

        SelectedModels.Rodent.IsPregnant = isPregnant == YesOrNoConverter.POSITIV;
        IsChanged = true;
    }

    private async void EditHallmarks()
    {
        string hallMarks = await Shell.Current.DisplayPromptAsync("Изменение отличительных черт", "Введите новое значение");

        if (string.IsNullOrWhiteSpace(hallMarks)) return;

        SelectedModels.Rodent.Hallmarks = hallMarks;
        IsChanged = true;
    }

    private async void EditBirthDay()
    {
        string date = await Shell.Current.DisplayPromptAsync("Изменение возраста", "Введите новое значение(в месяцах)");

        if (string.IsNullOrWhiteSpace(date) || !int.TryParse(date, out int months)) return;

        SelectedModels.Rodent.BirthDay = DateTime.Today.AddMonths(-months);
        IsChanged = true;
    }

    private void RestAfterChildbirth()
    {
        SelectedModels.Rodent.WereChildbirth = true;
        SelectedModels.Rodent.ChildbirthDate = DateTime.Today.AddDays(Rodent.RestAfterChildbirthInDays);
        IsChanged = true;
    }

    private void CancelRestAfterChildbirth()
    {
        SelectedModels.Rodent.WereChildbirth = false;
        SelectedModels.Rodent.ChildbirthDate = default;
        IsChanged = true;
    }

    private async void MoveRodentToNewClosetAndBox()
    {
        if (SelectedCloset == null || SelectedBox == null)
        {
            await Shell.Current.DisplayAlert("Неправильные данные", "Проверьте все поля на правильность", "ок");
            return;
        }

        SelectedModels.Rodent.ClosetId = SelectedCloset.Id;
        SelectedModels.Rodent.BoxId = SelectedBox.Id;

        await _database.Connection.UpdateAsync(SelectedModels.Rodent);
        await Shell.Current.DisplaySnackbar("Перемещение успешно");
    }

    private async void GoToRodentView()
    {
        await Shell.Current.GoToAsync(nameof(RodentView));
    }
}
