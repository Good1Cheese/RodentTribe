using RodentTribe.Data;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RodentTribe.ViewModels.Abstract;

public abstract class ViewModelBase<TModel> : NotifyPropertyChanged, ICRUDViewModel where TModel : new()
{
    protected readonly Database _database;

    public bool IsInEditMode { get; set; }
    public TModel Selected { get; set; }
    public ObservableCollection<TModel> List { get; private set; }

    public ICommand ToggleEditModeCommand { get; }
    public ICommand SelectCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }

    public ViewModelBase(Database database)
    {
        _database = database;

        Task.Run(async () =>
        {
            var list = await _database.Connection.Table<TModel>().ToListAsync();
            List = new(list);
        });

        ToggleEditModeCommand = new Command(ToggleEditMode);
        AddCommand = new Command(Add);
        DeleteCommand = new Command(Delete);
        SelectCommand = new Command(Select);
    }

    private void ToggleEditMode()
    {
        IsInEditMode = !IsInEditMode;
        OnPropertyChanged(nameof(IsInEditMode));
    }

    public abstract void Add(object obj);
    public abstract void Delete(object obj);
    public abstract void Select(object obj);
}
