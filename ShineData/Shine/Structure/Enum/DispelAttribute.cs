using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum;

public enum DispelAttribute : uint
{
    [Description("None")]
    DA_NONE = 0x0,
    [Description("Good")]
    DA_GOOD = 0x1,
    [Description("Debuff")]
    DA_DEBUFF = 0x2,
    [Description("Disease")]
    DA_DISEASE = 0x3,
    [Description("Poison")]
    DA_POISON = 0x4,
    [Description("Curse")]
    DA_CURSE = 0x5,
    [Description("Stun")]
    DA_STUN = 0x6,
    [Description("Fear")]
    DA_FEAR = 0x7,
    [Description("Deeper")]
    DA_DEEPER = 0x8,
    [Description("Hide")]
    DA_HIDE = 0x9,
    [Description("Bomb")]
    DA_BOMB = 0xA,
    [Description("Charged")]
    DA_CHARGED = 0xB
}