using SQLite;

namespace RodentTribe.Data.Models;

[Table("Boxes")]
public class Box : NameOnlyModel
{
    [Indexed]
    [Column("closet_id")]
    public int ClosetId { get; set; }
}
