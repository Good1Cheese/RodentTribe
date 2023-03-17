using RodentTribe.Data;
using RodentTribe.Data.Models;
using RodentTribe.ViewModels.Abstract;

namespace RodentTribe.ViewModels;

public class RodentViewModel : ViewModelBase<Rodent>
{
    public RodentViewModel(Database database)
        : base(database)
    {
        
    }

    public override async void Add(object obj)
    {
        // Go to edit view
    }

    public override async void Delete(object obj)
    {
        await _database.Connection.DeleteAsync(obj);
        List.Remove((Rodent)obj);
    }

    public override async void Select(object obj)
    {
        // Go to edit view
    }
}
