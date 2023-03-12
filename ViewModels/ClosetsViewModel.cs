using RodentTribe.Data;
using RodentTribe.Data.Models;
using SQLite;
using System.Windows.Input;

namespace RodentTribe.ViewModels;

public class ClosetsViewModel : ViewModelBase
{
    private readonly Database _database;

    public ClosetsViewModel(Database database)
    {
        _database = database;

        Closets = _database.Connection.Table<Сloset>();

        MoveToBoxSelectViewCommand = new Command(() => 
        {
            
            // navigate
        }); 
    }

    public TableQuery<Сloset> Closets { get; set; }
    public Сloset Selected { get; set; }
    public ICommand MoveToBoxSelectViewCommand { get; private set; }
}
