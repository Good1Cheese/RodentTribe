using RodentTribe.ViewModels;
using SQLite;

namespace RodentTribe.Data.Models;

[Table("Сlosets")]
public class Сloset : NotifyPropertyChanged
{
    private string _name;

    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [MaxLength(128)]
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }
}
