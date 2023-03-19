using System.Globalization;

namespace RodentTribe.Data.Converters;

public class BirthDayConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var dt = (DateTime)value;
        TimeSpan difference = DateTime.Today.Subtract(dt);

        return (int)(difference.TotalDays / 30);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return DateTime.Today.AddDays((int)value);
    }
}