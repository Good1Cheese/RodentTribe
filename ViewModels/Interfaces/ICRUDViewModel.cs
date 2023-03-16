namespace RodentTribe.ViewModels.Interfaces;

public interface ICRUDViewModel
{
    abstract void Add(object obj);
    abstract void Delete(object obj);
    abstract void Select(object obj);
}
