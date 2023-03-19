using RodentTribe.Data;
using RodentTribe.Data.Databases;
using RodentTribe.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RodentTribe.ViewModels.Abstract;

public abstract class ViewModelBase<TModel> : NotifyPropertyChanged, ICRUDViewModel where TModel : new()
{
    protected readonly Database _database;

    public bool IsInEditMode { get; set; }
    public ObservableCollection<TModel> Models { get; protected set; }

    public ICommand ToggleEditModeCommand { get; }
    public ICommand SelectCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }

    public ViewModelBase(Database database)
    {
        _database = database;

        Task.Run(GetModels);

        ToggleEditModeCommand = new Command(ToggleEditMode);
        AddCommand = new Command(Add);
        DeleteCommand = new Command(Delete);
        SelectCommand = new Command(Select);
    }

    protected virtual async Task GetModels()
    {
        var models = await _database.Connection.Table<TModel>().ToListAsync();
        Models = new(models);
    }

    private void ToggleEditMode()
    {
        IsInEditMode = !IsInEditMode;
        OnPropertyChanged(nameof(IsInEditMode));
    }

    public abstract void Add();
    public abstract void Delete(object obj);
    public abstract void Select(object obj);
}
