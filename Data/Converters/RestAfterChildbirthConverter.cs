using System.Globalization;

namespace RodentTribe.Data.Converters;

public class RestAfterChildbirthConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var dt = (DateTime)value;

        return dt.Subtract(DateTime.Today).Days;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return DateTime.Today.Subtract(new TimeSpan((int)value, 0, 0, 0));
    }
}
