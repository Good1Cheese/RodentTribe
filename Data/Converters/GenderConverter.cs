using System.Globalization;

namespace RodentTribe.Data.Converters;

public class GenderConverter : IValueConverter
{
    public const string MALE = "Самец";
    public const string FEMALE = "Самка";

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? MALE : FEMALE;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (string)value == MALE ? true : false;
    }
}
