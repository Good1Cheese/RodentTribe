namespace RodentTribe.Data.Models;

public static class AgeCategory
{
    public static readonly string[] Names = new string[] 
    {
        "Голыш",
        "Подросток",
        "Взрослый"
    };

    public enum Categories
    {
        Germ = 0,
        Teenager = 1,
        Adult = 2
    }

    public static Categories GetCategoryByName(string value)
    {
        return (Categories)Array.IndexOf(Names, value);
    }
}
