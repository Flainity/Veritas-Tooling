using System;
using System.Globalization;
using System.Windows.Data;
using ShineData.Shine.Structure.Enum;
using ShineData.Shine.Structure.Enum.Action;

namespace ShineSuite.Converter;

public class EnumTypeSelectorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
            return null;

        var actionTargetType = (ActionTargetType)value;

        switch (actionTargetType)
        {
            case ActionTargetType.ATT_TARGET_TYPE:
                return typeof(TargetType);
            case ActionTargetType.ATT_MOB_GRADE_TYPE:
                return typeof(MobGradeType);
            case ActionTargetType.ATT_MOB_TYPE:
                return typeof(MobType);
            case ActionTargetType.ATT_CHARACTER_CLASS_TYPE:
                return typeof(CharacterClassType);
            default:
                return null;
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}