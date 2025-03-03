using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum;

public enum RecoverType : uint
{
    [Description("Absolute Health Plus")]
    RT_HPABSOLUTEPLUS,
    [Description("Health Rate Plus")]
    RT_HPRATEPLUS,
    [Description("Absolute Mana Plus")]
    RT_SPABSOLUTEPLUS,
    [Description("Mana Rate Plus")]
    RT_SPRATEPLUS,
    [Description("Absolute Health Minus")]
    RT_HPABSOLUTEMINUS,
    [Description("Health Rate Minus")]
    RT_HPRATEMINUS,
    [Description("Absolute Mana Minus")]
    RT_SPABSOLUTEMINUS,
    [Description("Mana Rate Minus")]
    RT_SPRATEMINUS,
}