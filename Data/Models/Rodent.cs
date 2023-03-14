using SQLite;

namespace RodentTribe.Data.Models;

[Table("Rodents")]
public class Rodent
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [Column("age")]
    public int Age { get; set; }

    [Column("is_male")]
    public bool IsMale { get; set; }

    [Column("is_pregnant")]
    public bool IsPregnant { get; set; }
}
