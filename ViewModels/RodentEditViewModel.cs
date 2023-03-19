using CommunityToolkit.Maui.Alerts;
using Java.Util;
using RodentTribe.Data;
using RodentTribe.Data.Converters;
using RodentTribe.Data.Databases;
using RodentTribe.Data.Models;
using RodentTribe.Views;
using System.Windows.Input;

namespace RodentTribe.ViewModels;

public class RodentEditViewModel
{
    private readonly Database _database;

    public ICommand EditAgeCategoryCommand { get; }
    public ICommand EditGenderCommand { get; }
    public ICommand EditPregnantStatusCommand { get; }
    public ICommand EditHallmarksCommand { get; }
    public ICommand EditBirthDayCommand { get; }
    public ICommand GoToRodentViewCommand { get; }
    public bool IsChanged { get; set; }

    public RodentEditViewModel(Database database)
    {
        _database = database;

        EditAgeCategoryCommand = new Command(EditAgeCategory);
        EditGenderCommand = new Command(EditGender);
        EditPregnantStatusCommand = new Command(EditPregnantStatus);
        EditHallmarksCommand = new Command(EditHallmarks);
        EditBirthDayCommand = new Command(EditBirthDay);
        GoToRodentViewCommand = new Command(GoToRodentView);
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
        var categoryName = await Shell.Current.DisplayActionSheet("Выбор возрастной категори", "Отмена", null, AgeCategory.Names);
        var category = AgeCategory.GetCategoryByName(categoryName);

        SelectedModels.Rodent.Category = category;
        IsChanged = true;
    }

    private async void EditGender()
    {
        var gender = await Shell.Current.DisplayActionSheet("Выбор пола", "Отмена", null, Rodent.MALE, Rodent.FEMALE);

        SelectedModels.Rodent.IsMale = gender == Rodent.MALE;
        IsChanged = true;
    }

    private async void EditPregnantStatus()
    {
        var isPregnant = await Shell.Current.DisplayActionSheet("Изменение беременности", "Отмена", null, YesOrNoConverter.POSITIV, YesOrNoConverter.NEGATIV);

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

    private async void GoToRodentView()
    {
        await Shell.Current.GoToAsync(nameof(RodentView));
    }
}
