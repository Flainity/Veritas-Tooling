using ShineData.Shine.Structure.Enum;
using ShineData.Shine.Structure.Enum.Action;
using ShineData.Shine.Structure.Enum.Action.Activity;
using ShineData.Shine.Structure.Enum.Action.Activity.Enum;
using ShineData.Shine.Wrapper;

namespace ShineData.Shine.Files;

public class ItemActionEffectEntry : IShineEntry
{
    public ushort Id { get; set; }
    public ActionTargetWrapper EffectTarget { get; set; }
    public ActionActivityWrapper EffectActivity { get; set; }
    public ushort Value { get; set; }
    public ushort Area { get; set; }
    public string Explanation { get; set; }
    
    public ItemActionEffectEntry() {}
    
    public ItemActionEffectEntry(ushort id, Tuple<uint, uint> effectTarget, Tuple<uint, uint> effectActivity, ushort value, ushort area, string explanation)
    {
        Id = id;

        EffectTarget = new ActionTargetWrapper
        {
            TargetItem01 = (ActionTargetType) effectTarget.Item1,
            TargetItem02 = (ActionTargetType) effectTarget.Item1 switch
            {
                ActionTargetType.ATT_TARGET_TYPE => new TargetTypeEnum((TargetType) effectTarget.Item2),
                ActionTargetType.ATT_MOB_GRADE_TYPE => new MobGradeTypeEnum((MobGradeType) effectTarget.Item2),
                ActionTargetType.ATT_MOB_TYPE => new MobTypeEnum((MobType) effectTarget.Item2),
                ActionTargetType.ATT_CHARACTER_CLASS_TYPE => new CharacterClassTypeEnum(
                    (CharacterClassType) effectTarget.Item2),
                _ => throw new ArgumentOutOfRangeException(nameof(effectTarget), "Invalid Target")
            }
        };
        
        EffectActivity = new ActionActivityWrapper
        {
            TargetItem01 = (ActionActivityType) effectActivity.Item1,
            TargetItem02 = (ActionActivityType) effectActivity.Item1 switch
            {
                ActionActivityType.AAT_ATTACK_TYPE => new AttackTypeEnum((AttackType) effectActivity.Item2),
                ActionActivityType.AAT_RECOVER_TYPE => new RecoverTypeEnum((RecoverType) effectActivity.Item2),
                ActionActivityType.AAT_ABSTATE_INDEX => new AbstateIndexEnum((DummyType) effectActivity.Item2),
                ActionActivityType.AAT_DISPEL_ATTRIBUTE => new DispelAttributeEnum((DispelAttribute) effectActivity.Item2),
                ActionActivityType.AAT_TARGET_ACTION => new TargetActionEnum((TargetAction) effectActivity.Item2),
                ActionActivityType.AAT_SKILL_EFFECT_INCREASE => new SkillEffectIncreaseEnum((SkillEffectIncreaseType) effectActivity.Item2),
                ActionActivityType.AAT_ACTION_RANGE_TYPE => new ActionRangeEnum((ActionRangeType) effectActivity.Item2),
                ActionActivityType.AAT_ACTIVE_SKILL_GROUP_INDEX => new ActiveSkillGroupIndexEnum((DummyType) effectActivity.Item2),
                ActionActivityType.AAT_ACTION_ETC_TYPE => new ActionEquipEnum((ActionEquipType) effectActivity.Item2),
                ActionActivityType.AAT_SET_ITEM_EFFECT_TYPE => new SetItemEffectEnum((SetItemEffectType) effectActivity.Item2),
                _ => throw new ArgumentOutOfRangeException(nameof(effectActivity), "Invalid Activity")
            }
        };
        
        Value = value;
        Area = area;
        Explanation = explanation;
    }
}