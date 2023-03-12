using SQLite;

namespace RodentTribe.Data.Models;

[Table("Boxes")]
public class Box
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }
}
