using SQLite;

namespace RodentTribe.Data.Models;

public class NameOnlyModel : NotifyPropertyChanged
{
    private int _id;
    private string _name;

    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get => _id; set => _id = value; }

    [Column("name")]
    [MaxLength(64)]
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