using System.Globalization;

namespace RodentTribe.Data.Converters;

public class YesOrNoConverter : IValueConverter 
{
    public const string POSITIV = "Да";
    public const string NEGATIV = "Нет";

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? POSITIV : NEGATIV;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (string)value == POSITIV;
    }
}
