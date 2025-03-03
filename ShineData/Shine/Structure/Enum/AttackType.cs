using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum;

public enum AttackType
{
    [Description("Normal Attack")]
    AT_NORMAL = 0,
    [Description("Skill")]
    AT_SKILL = 1,
    [Description("Magic Attack")]
    AT_MAGIC = 2,
    [Description("Physical Attack")]
    AT_PHYSIC = 3,
    [Description("Critical Attack")]
    AT_CRITICAL = 4,
    [Description("Miss Attack")]
    AT_MISS = 5,
    [Description("Block Attack")]
    AT_BLOCK = 6
}