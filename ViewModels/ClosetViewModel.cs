using RodentTribe.Data;
using RodentTribe.Data.Models;
using SQLite;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RodentTribe.ViewModels;

public class ClosetViewModel : NotifyPropertyChanged
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
    public Сloset Selected { get; set; }
    public ObservableCollection<Сloset> Closets { get; private set; }

    public ClosetViewModel(Database database)
    {
        _database = database;

        Task.Run(async () =>
        {
            var сlosets = await _database.Connection.Table<Сloset>().ToListAsync();
            Closets = new(сlosets);
        });

        ToggleEditModeCommand = new Command(_ => IsInEditMode = !IsInEditMode);
        AddCommand = new Command(Add);
        DeleteCommand = new Command(Delete);
        SelectCommand = new Command(Select);
    }

    private async void Add(object obj)
    {
        var newItem = new Сloset() { Name = "Новая запись" };
        await _database.Connection.InsertAsync(newItem);
        Closets.Add(newItem);
    }

    private async void Delete(object obj)
    {
        await _database.Connection.DeleteAsync(obj);
        Closets.Remove((Сloset)obj);
    }

    private async void Select(object obj)
    {
        Selected = (Сloset)obj;

        if (IsInEditMode)
        {
            await RenameSelected(Selected);
            return;
        }

        await MoveToBoxView();
    }

    private async Task RenameSelected(Сloset closet)
    {
        string newName = await Shell.Current.DisplayPromptAsync("Переименование", "Введите новое значение");

        if (string.IsNullOrWhiteSpace(newName)) return;

        closet.Name = newName;
        await _database.Connection.UpdateAsync(closet);
    }

    private static async Task MoveToBoxView()
    {
        await Shell.Current.GoToAsync(nameof(Views.BoxView));
    }
}
