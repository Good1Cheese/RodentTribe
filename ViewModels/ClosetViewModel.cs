using RodentTribe.Data;
using RodentTribe.Data.Models;
using SQLite;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace RodentTribe.ViewModels;

public class ClosetViewModel : ViewModelBase
{
    private readonly Database _database;
    private bool _isInEditMode;
    private Сloset _selected;
    private TableQuery<Сloset> closets;

    public bool IsInEditMode
    {
        get => _isInEditMode;
        set
        {
            _isInEditMode = value;
            OnPropertyChanged();
        }
    }

    public Сloset Selected
    {
        get => _selected;
        set
        {
            _selected = value;
            OnPropertyChanged();
        }
    }

    public TableQuery<Сloset> Closets
    {
        get => closets;
        set
        {
            closets = value;
            OnPropertyChanged();
        }
    }

    public ICommand ToggleEditModeCommand { get; }
    public ICommand SelectCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand RenameCommand { get; }

    public ClosetViewModel(Database database)
    {
        _database = database;

        Closets = _database.Connection.Table<Сloset>();

        ToggleEditModeCommand = new Command(_ => IsInEditMode = !IsInEditMode);

        SelectCommand = new Command(async obj =>
        {
            Selected = (Сloset)obj;

            if (IsInEditMode)
            {
                await RenameSelected();
                return;
            }

            await MoveToBoxView();
        });

        AddCommand = new Command(obj =>
        {
            var newItem = new Сloset() { Name = "Новая запись" };
            _database.Connection.Insert(newItem);
            Closets = _database.Connection.Table<Сloset>();
        });

        DeleteCommand = new Command(obj =>
        {
            _database.Connection.Delete(obj);
            Closets = _database.Connection.Table<Сloset>();
        });
    }

    private async Task RenameSelected()
    {
        string newName = await Shell.Current.DisplayPromptAsync("Переименование", "Введите новое значение");

        Selected.Name = newName;
        _database.Connection.Update(Selected);
        Closets = _database.Connection.Table<Сloset>();
    }

    private static async Task MoveToBoxView() => await Shell.Current.GoToAsync(nameof(Views.BoxView));
}
