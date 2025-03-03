using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum;

public enum EffectPosition : uint
{
    [Description("None")]
    EP_NONE = 0,
    [Description("Ground")]
    EP_GROUND = 1,
    [Description("Chest")]
    EP_CHEST = 2,
    [Description("Hair")]
    EP_HAIR_LINK = 3,
    [Description("OP Ground")]
    EP_OP_GROUND = 4,
    [Description("OP Chest")]
    EP_OP_CHEST = 5,
    [Description("Back")]
    EP_BACK = 6,
    [Description("Top")]
    EP_TOP_LINK = 7,
    [Description("OP Top")]
    EP_OP_TOP_LINK = 8
}