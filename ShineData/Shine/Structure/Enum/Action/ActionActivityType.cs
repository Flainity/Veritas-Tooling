using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum.Action;

public enum ActionActivityType : uint
{
    [Description("Attacks")]
    AAT_ATTACK_TYPE,
    [Description("Recovers")]
    AAT_RECOVER_TYPE,
    [Description("Abstate")]
    AAT_ABSTATE_INDEX,
    [Description("Dispels")]
    AAT_DISPEL_ATTRIBUTE,
    [Description("Target Action")]
    AAT_TARGET_ACTION,
    [Description("Skill Effect Increase")]
    AAT_SKILL_EFFECT_INCREASE,
    [Description("Range Type")]
    AAT_ACTION_RANGE_TYPE,
    [Description("Active Skill Group Index")]
    AAT_ACTIVE_SKILL_GROUP_INDEX,
    [Description("Item Effect")]
    AAT_ACTION_ETC_TYPE,
    [Description("Set Item Effect")]
    AAT_SET_ITEM_EFFECT_TYPE,
}