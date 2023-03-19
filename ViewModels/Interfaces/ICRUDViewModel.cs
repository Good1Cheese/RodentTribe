namespace RodentTribe.ViewModels.Interfaces;

public interface ICRUDViewModel
{
    abstract void Add();
    abstract void Delete(object obj);
    abstract void Select(object obj);
}
