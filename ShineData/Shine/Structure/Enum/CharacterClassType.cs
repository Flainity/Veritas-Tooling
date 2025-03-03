using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum;

public enum CharacterClassType : uint
{
    [Description("Fighter")]
    CCT_FIGHTER,
    [Description("Archer")]
    CCT_ARCHER,
    [Description("Cleric")]
    CCT_CLERIC,
    [Description("Mage")]
    CCT_MAGE,
    [Description("Joker")]
    CCT_JOKER,
    [Description("Crusader")]
    CCT_CRUSADER,
    [Description("Every Class")]
    CCT_COMMON
}