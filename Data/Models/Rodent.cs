using SQLite;
using System;

namespace RodentTribe.Data.Models;

[Table("Rodents")]
public partial class Rodent : NotifyPropertyChanged
{
    public const string MALE = "Самец";
    public const string FEMALE = "Самка";
    public static readonly int RestAfterChildbirthInDays = 30;  

    private AgeCategory.Categories _category;
    private Rodents.Types _type;
    private bool _isMale;
    private bool _isPregnant;
    private string _hallmarks;
    private DateTime _birthDay;
    private bool _wereChildbirth;
    private DateTime _childbirthDate;

    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [Column("age_category")]
    public AgeCategory.Categories Category
    {
        get => _category;
        set
        {
            _category = value;
            OnPropertyChanged();
        }
    }

    [Column("rodent_type")]
    public Rodents.Types Type
    {
        get => _type;
        set
        {
            _type = value;
            OnPropertyChanged();
        }
    }

    [Column("is_male")]
    public bool IsMale
    {
        get => _isMale;
        set
        {
            _isMale = value;
            OnPropertyChanged();
        }
    }

    [Column("is_pregnant")]
    public bool IsPregnant
    {
        get => _isPregnant;
        set
        {
            _isPregnant = value;
            OnPropertyChanged();
        }
    }

    [Column("hall_marks")]
    public string Hallmarks
    {
        get => _hallmarks;
        set
        {
            _hallmarks = value;
            OnPropertyChanged();
        }
    }

    [Column("birth_day")]
    public DateTime BirthDay
    {
        get => _birthDay;
        set
        {
            _birthDay = value;
            OnPropertyChanged();
        }
    }

    [Column("were_childbirth")]
    public bool WereChildbirth
    {
        get => _wereChildbirth;
        set
        {
            _wereChildbirth = value;
            OnPropertyChanged();
        }
    }

    [Column("childbirth_date")]
    public DateTime ChildbirthDate
    {
        get => _childbirthDate;
        set
        {
            _childbirthDate = value;
            OnPropertyChanged();
        }
    }

    [Indexed]
    [Column("closet_id")]
    public int ClosetId { get; set; }

    [Indexed]
    [Column("box_id")]
    public int BoxId { get; set; }
}
