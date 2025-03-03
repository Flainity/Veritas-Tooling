using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum;

public enum WeaponDemandType
{
    [Description("One Hand Sword")]
    DT_ONEHAND = 0x0,
    [Description("Two Hand Sword")]
    DT_TWOHAND = 0x1,
    [Description("All (MOB SKILLS ONLY!)")]
    DT_ALL = 0x2,
    [Description("Any Weapon")]
    DT_WEAPON = 0x3,
    [Description("Hammer")]
    DT_HAMMER = 0x4,
    [Description("Mace")]
    DT_MACE = 0x5,
    [Description("None")]
    DT_NONE = 0x6,
    [Description("Shield")]
    DT_SHIELD = 0x7,
    [Description("Bow")]
    DT_BOW = 0x8,
    [Description("Crossbow")]
    DT_CBOW = 0x9,
    [Description("Staff")]
    DT_STAFF = 0xA,
    [Description("Wand")]
    DT_WAND = 0xB,
    [Description("Claw")]
    DT_CLAW = 0xC,
    [Description("Dual Sword")]
    DT_DSWORD = 0xD,
    [Description("Blade")]
    DT_BLADE = 0xE
};