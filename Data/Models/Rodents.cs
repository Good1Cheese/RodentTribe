namespace RodentTribe.Data.Models;

public static class Rodents
{
    public static readonly string[] Names = new string[]
    {
        "Крыса",
        "Мышь",
        "Хомяк"
    };

    public enum Types
    {
        Rat = 0,
        Mouse = 1,
        Hamster = 2
    }

    public static Types GetTypeByName(string value)
    {
        return (Types)Array.IndexOf(Names, value);
    }
}