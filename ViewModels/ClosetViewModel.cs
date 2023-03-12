using RodentTribe.Data;
using RodentTribe.Data.Models;
using RodentTribe.Views;
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

        MoveToBoxSelectCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync(nameof(BoxSelectView));
        });
    }

    public TableQuery<Сloset> Closets { get; set; }
    public Сloset Selected { get; set; }
    public ICommand MoveToBoxSelectCommand { get; private set; }
}
