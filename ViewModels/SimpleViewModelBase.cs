using RodentTribe.Data;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RodentTribe.ViewModels;

public abstract class SimpleViewModel<TModel> : NotifyPropertyChanged, ICRUDViewModel where TModel : NameOnlyModel, new()
{
    private readonly Database _database;
    private bool _isInEditMode;

    public bool IsInEditMode
    {
        get => _isInEditMode;
        set
        {
            _isInEditMode = value;
            OnPropertyChanged();
        }
    }

    public ICommand ToggleEditModeCommand { get; }
    public ICommand SelectCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public TModel Selected { get; set; }
    public ObservableCollection<TModel> List { get; private set; }

    public SimpleViewModel(Database database)
    {
        _database = database;

        Task.Run(async () =>
        {
            var list = await _database.Connection.Table<TModel>().ToListAsync();
            List = new(list);
        });

        ToggleEditModeCommand = new Command(_ => IsInEditMode = !IsInEditMode);
        AddCommand = new Command(Add);
        DeleteCommand = new Command(Delete);
        SelectCommand = new Command(Select);
    }

    public async void Add(object obj)
    {
        var newItem = new TModel() { Name = "Новая запись" };
        await _database.Connection.InsertAsync(newItem);
        List.Add(newItem);
    }

    public async void Delete(object obj)
    {
        await _database.Connection.DeleteAsync(obj);
        List.Remove((TModel)obj);
    }

    public async void Select(object obj)
    {
        Selected = (TModel)obj;

        if (IsInEditMode)
        {
            await RenameSelected(Selected);
            return;
        }

        await MoveToNextView();
    }

    private async Task RenameSelected(TModel model)
    {
        string newName = await Shell.Current.DisplayPromptAsync("Переименование", "Введите новое значение");

        if (string.IsNullOrWhiteSpace(newName)) return;

        model.Name = newName;
        await _database.Connection.UpdateAsync(model);
    }

    protected abstract Task MoveToNextView();
}
