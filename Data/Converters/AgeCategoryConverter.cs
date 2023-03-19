using System.Globalization;
using RodentTribe.Data.Models;

namespace RodentTribe.Data.Converters;

public class AgeCategoryConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return AgeCategory.Names[(int)value];
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)AgeCategory.GetCategoryByName((string)value);
    }
}
