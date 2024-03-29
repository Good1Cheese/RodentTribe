﻿using RodentTribe.Data.Models;
using System.Globalization;

namespace RodentTribe.Data.Converters;

public class GenderConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? Rodent.MALE : Rodent.FEMALE;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (string)value == Rodent.MALE;
    }
}
