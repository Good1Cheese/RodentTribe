using RodentTribe.Data;
using RodentTribe.Data.Models;
using RodentTribe.Views;
using SQLite;
using System.Windows.Input;

namespace RodentTribe.ViewModels;

public class BoxViewModel
{
    private readonly Database _database;

    public BoxViewModel(Database database)
    {
        _database = database;

        Boxes = _database.Connection.Table<Box>();

        MoveToRodentViewCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync(nameof(RodentView));
        });
    }

    public TableQuery<Box> Boxes { get; set; }
    public Box Selected { get; set; }
    public ICommand MoveToRodentViewCommand { get; private set; }
}