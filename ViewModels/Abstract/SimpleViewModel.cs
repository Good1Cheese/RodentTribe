using RodentTribe.Data.Databases;
using RodentTribe.Data.Models;

namespace RodentTribe.ViewModels.Abstract;

public abstract class SimpleViewModel<TModel> : ViewModelBase<TModel> where TModel : NameOnlyModel, new()
{
    public SimpleViewModel(Database database)
        : base(database)
    {
    }

    public override async void Add()
    {
        var newItem = new TModel() { Name = "Новая запись" };
        await _database.Connection.InsertAsync(newItem);
        Models.Add(newItem);
    }

    public override async void Delete(object obj)
    {
        await _database.Connection.DeleteAsync(obj);
        Models.Remove((TModel)obj);
    }

    public override async void Select(object obj)
    {
        if (IsInEditMode)
        {
            await RenameSelected((TModel)obj);
            return;
        }

        GoToNextView();
    }

    private async Task RenameSelected(TModel model)
    {
        string name = await Shell.Current.DisplayPromptAsync("Переименование", "Введите новое значение");

        if (string.IsNullOrWhiteSpace(name)) return;

        model.Name = name;
        await _database.Connection.UpdateAsync(model);
    }

    protected abstract void GoToNextView();
}
