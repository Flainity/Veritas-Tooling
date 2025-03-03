using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum.Action.Activity.Enum;

public enum SetItemEffectType : uint
{
    [Description("Default")]
    SIET_DEFAULT = 0,
    [Description("Damage Rate Increase")]
    SIET_DAMAGE_RATE_INCREASE = 1
}