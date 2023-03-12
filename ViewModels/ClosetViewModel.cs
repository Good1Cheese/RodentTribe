using RodentTribe.Data;
using RodentTribe.Data.Models;
using SQLite;
using System.Windows.Input;

namespace RodentTribe.ViewModels;

public class ClosetViewModel : ViewModelBase
{
    private readonly Database _database;

    public ClosetViewModel(Database database)
    {
        _database = database;

        Closets = _database.Connection.Table<Сloset>();

        MoveToBoxViewCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync(nameof(Views.BoxView));
        });
    }

    public TableQuery<Сloset> Closets { get; set; }
    public Сloset Selected { get; set; }
    public ICommand MoveToBoxViewCommand { get; private set; }
}
