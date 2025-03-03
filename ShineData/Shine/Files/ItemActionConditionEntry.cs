using ShineData.Shine.Structure.Enum;
using ShineData.Shine.Structure.Enum.Action;
using ShineData.Shine.Structure.Enum.Action.Activity;
using ShineData.Shine.Structure.Enum.Action.Activity.Enum;
using ShineData.Shine.Wrapper;

namespace ShineData.Shine.Files;

public class ItemActionConditionEntry : IShineEntry
{
    public ushort Id { get; set; }
    public ActionTargetWrapper SubjectTarget { get; set; }
    public ActionTargetWrapper ObjectTarget { get; set; }
    public ActionActivityWrapper ConditionActivity { get; set; }
    public ushort ActivityRate { get; set; }
    public ushort Range { get; set; }

    public ItemActionConditionEntry()
    {
        SubjectTarget = new ActionTargetWrapper();
    }
    
    public ItemActionConditionEntry(ushort id, Tuple<uint, uint> subjectTarget, Tuple<uint, uint> objectTarget, Tuple<uint, uint> conditionActivity, ushort activityRate, ushort range)
    {
        Id = id;

        SubjectTarget = new ActionTargetWrapper
        {
            TargetItem01 = (ActionTargetType) subjectTarget.Item1,
            TargetItem02 = (ActionTargetType) subjectTarget.Item1 switch
            {
                ActionTargetType.ATT_TARGET_TYPE => new TargetTypeEnum((TargetType)subjectTarget.Item2),
                ActionTargetType.ATT_MOB_GRADE_TYPE => new MobGradeTypeEnum((MobGradeType)subjectTarget.Item2),
                ActionTargetType.ATT_MOB_TYPE => new MobTypeEnum((MobType)subjectTarget.Item2),
                ActionTargetType.ATT_CHARACTER_CLASS_TYPE => new CharacterClassTypeEnum((CharacterClassType)subjectTarget.Item2),
                _ => throw new ArgumentOutOfRangeException()
            }
        };

        ObjectTarget = new ActionTargetWrapper
        {
            TargetItem01 = (ActionTargetType) objectTarget.Item1,
            TargetItem02 = (ActionTargetType) objectTarget.Item1 switch
            {
                ActionTargetType.ATT_TARGET_TYPE => new TargetTypeEnum((TargetType)objectTarget.Item2),
                ActionTargetType.ATT_MOB_GRADE_TYPE => new MobGradeTypeEnum((MobGradeType)objectTarget.Item2),
                ActionTargetType.ATT_MOB_TYPE => new MobTypeEnum((MobType)objectTarget.Item2),
                ActionTargetType.ATT_CHARACTER_CLASS_TYPE => new CharacterClassTypeEnum((CharacterClassType)objectTarget.Item2),
                _ => throw new ArgumentOutOfRangeException()
            }
        };

        ConditionActivity = new ActionActivityWrapper
        {
            TargetItem01 = (ActionActivityType) conditionActivity.Item1,
            TargetItem02 = (ActionActivityType) conditionActivity.Item1 switch
            {
                ActionActivityType.AAT_ATTACK_TYPE => new AttackTypeEnum((AttackType) conditionActivity.Item2),
                ActionActivityType.AAT_RECOVER_TYPE => new RecoverTypeEnum((RecoverType) conditionActivity.Item2),
                ActionActivityType.AAT_ABSTATE_INDEX => new AbstateIndexEnum((DummyType) conditionActivity.Item2),
                ActionActivityType.AAT_DISPEL_ATTRIBUTE => new DispelAttributeEnum((DispelAttribute) conditionActivity.Item2),
                ActionActivityType.AAT_TARGET_ACTION => new TargetActionEnum((TargetAction) conditionActivity.Item2),
                ActionActivityType.AAT_SKILL_EFFECT_INCREASE => new SkillEffectIncreaseEnum((SkillEffectIncreaseType) conditionActivity.Item2),
                ActionActivityType.AAT_ACTION_RANGE_TYPE => new ActionRangeEnum((ActionRangeType) conditionActivity.Item2),
                ActionActivityType.AAT_ACTIVE_SKILL_GROUP_INDEX => new ActiveSkillGroupIndexEnum((DummyType) conditionActivity.Item2),
                ActionActivityType.AAT_ACTION_ETC_TYPE => new ActionEquipEnum((ActionEquipType) conditionActivity.Item2),
                ActionActivityType.AAT_SET_ITEM_EFFECT_TYPE => new SetItemEffectEnum((SetItemEffectType) conditionActivity.Item2),
                _ => throw new ArgumentOutOfRangeException()
            }
        };
        
        ActivityRate = activityRate;
        Range = range;
    }
}