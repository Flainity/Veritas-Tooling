using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum;

public enum StateType : uint
{
    [Description("Normal")]
    ST_NORMAL = 0,
    [Description("Skill")]
    ST_SKILL = 1,
    [Description("Scroll")]
    ST_SCROLL = 2,
    [Description("Potion")]
    ST_POTION = 3,
    [Description("Debuff")]
    ST_DEBUFF = 4
}