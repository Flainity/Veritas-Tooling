using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum.Action.Activity.Enum;

public enum ActionRangeType : uint
{
    [Description("HP Rate 0-20%")]
    ART_HP_RATE_0_20 = 0,
    [Description("Level 0-40")]
    ART_LEVEL_0_40 = 1,
    [Description("SP Absolute 0-1000")]
    ART_SP_ABSOLUTE_0_1000 = 2,
    [Description("Level 0-19")]
    ART_LEVEL_0_19 = 3,
    [Description("Level 20-49")]
    ART_LEVEL_20_49 = 4,
    [Description("Level 50-79")]
    ART_LEVEL_50_79 = 5,
    [Description("Level 80-99")]
    ART_LEVEL_80_99 = 6,
    [Description("Level 100-150")]
    ART_LEVEL_100_150 = 7
}