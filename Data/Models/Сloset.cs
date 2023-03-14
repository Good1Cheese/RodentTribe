using SQLite;

namespace RodentTribe.Data.Models;

[Table("Сlosets")]
public class Сloset
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [MaxLength(128)]
    public string Name { get; set; }
}
