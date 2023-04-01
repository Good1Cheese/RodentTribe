using System.Globalization;
using RodentTribe.Data.Models;

namespace RodentTribe.Data.Converters;

public class TypeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Rodents.Names[(int)value];
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)Rodents.GetTypeByName((string)value);
    }
}