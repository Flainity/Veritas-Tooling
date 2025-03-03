using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum;

public enum MobGradeType : uint
{
    [Description("Normal")]
    MGT_NORMAL,
    [Description("Chief")]
    MGT_CHIEF,
    [Description("Boss")]
    MGT_BOSS,
    [Description("Hero")]
    MGT_HERO,
    [Description("Elite")]
    MGT_ELITE,
    [Description("None")]
    MGT_NONE
}