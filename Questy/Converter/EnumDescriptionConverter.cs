using System;
using System.Globalization;
using System.Windows.Data;
using ShineData.Shine.Extension;

namespace Questy.Converter;

public class EnumDescriptionConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Enum enumValue)
        {
            return enumValue.GetDescription();
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string description)
        {
            foreach (var enumValue in Enum.GetValues(targetType))
            {
                if ((enumValue as Enum).GetDescription() == description)
                {
                    return enumValue;
                }
            }
        }
        return null;
    }
}