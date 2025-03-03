using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum.Action;

public enum ActionTargetType : uint
{
    [Description("Target")]
    ATT_TARGET_TYPE = 0,
    [Description("Mob Grade")]
    ATT_MOB_GRADE_TYPE = 1,
    [Description("Mob Type")]
    ATT_MOB_TYPE = 2,
    [Description("Character Class")]
    ATT_CHARACTER_CLASS_TYPE = 3
}