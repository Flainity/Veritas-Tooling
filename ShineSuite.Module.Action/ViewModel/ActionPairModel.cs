using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using ShineData.Shine.Files;
using ShineData.Shine.Structure.Enum;
using ShineData.Shine.Structure.Enum.Action;
using ShineData.Shine.Structure.Enum.Action.Activity;
using ShineData.Shine.Structure.Enum.Action.Activity.Enum;
using ShineSuite.Common.Manager;

namespace ShineSuite.Module.Action.ViewModel;

public partial class ActionPairModel : ObservableObject
{
    [ObservableProperty] private ItemActionEntry _action;
    [ObservableProperty] private ItemActionEffectEntry _effect;
    [ObservableProperty] private ItemActionConditionEntry _condition;
    
    [ObservableProperty] private ActionTargetType _selectedObjectActionTargetType;
    [ObservableProperty] private ObservableCollection<Enum> _objectActionConditionTypes;

    [ObservableProperty] private ActionTargetType _selectedSubjectActionTargetType;
    [ObservableProperty] private ObservableCollection<Enum> _subjectConditionTypes;
    
    [ObservableProperty] private ActionActivityType _selectedActionActivityType;
    [ObservableProperty] private ObservableCollection<Enum> _activityTypes;
    
    [ObservableProperty] private ActionTargetType _selectedEffectTargetType;
    [ObservableProperty] private ObservableCollection<Enum> _effectTargetTypes;
    
    [ObservableProperty] private ActionActivityType _selectedEffectActivityType;
    [ObservableProperty] private ObservableCollection<Enum> _effectActivityTypes;

    public ActionPairModel(ItemActionEntry action)
    {
        Action = action;
        Effect = ShineFileManager.Instance.ItemActionEffect.Records
            .FirstOrDefault(x => x.Id == action.EffectId)!;
        Condition = ShineFileManager.Instance.ItemActionCondition.Records
            .FirstOrDefault(x => x.Id == action.ConditionId)!;

        SelectedSubjectActionTargetType = Condition.SubjectTarget.TargetItem01;
        SelectedObjectActionTargetType = Condition.ObjectTarget.TargetItem01;
        SelectedActionActivityType = Condition.ConditionActivity.TargetItem01;
        SelectedEffectTargetType = Effect.EffectTarget.TargetItem01;
        SelectedEffectActivityType = Effect.EffectActivity.TargetItem01;
        
        SelectedSubjectActionConditionType = GetEnumValueForTarget(Condition.SubjectTarget.TargetItem02, SelectedSubjectActionTargetType);
        SelectedObjectActionConditionType = GetEnumValueForTarget(Condition.ObjectTarget.TargetItem02, SelectedObjectActionTargetType);
        SelectedActionActivityConditionType = GetEnumValueForActivity(Condition.ConditionActivity.TargetItem02, SelectedActionActivityType);
        SelectedEffectTargetConditionType = GetEnumValueForTarget(Effect.EffectTarget.TargetItem02, SelectedEffectTargetType);
        SelectedEffectActivityConditionType = GetEnumValueForActivity(Effect.EffectActivity.TargetItem02, SelectedEffectActivityType);
        
        UpdateEnumValues();
    }
    
    partial void OnSelectedObjectActionTargetTypeChanged(ActionTargetType value)
    {
        if (Condition != null)
        {
            Condition.ObjectTarget.TargetItem01 = value;
        }
        UpdateEnumValuesForObject();
    }

    partial void OnSelectedSubjectActionTargetTypeChanged(ActionTargetType value)
    {
        if (Condition != null)
        {
            Condition.SubjectTarget.TargetItem01 = value;
        }
        UpdateEnumValuesForSubject();
    }

    partial void OnSelectedActionActivityTypeChanged(ActionActivityType value)
    {
        if (Condition != null)
        {
            Condition.ConditionActivity.TargetItem01 = value;
        }
        UpdateEnumValuesForActivity();
    }

    partial void OnSelectedEffectTargetTypeChanged(ActionTargetType value)
    {
        Effect.EffectTarget.TargetItem01 = value;
        UpdateEnumValuesForEffectTarget();
    }
    
    partial void OnSelectedEffectActivityTypeChanged(ActionActivityType value)
    {
        Effect.EffectActivity.TargetItem01 = value;
        UpdateEnumValuesForEffectActivity();
    }
    
    public Enum? SelectedEffectTargetConditionType
    {
        get
        {
            return GetEnumValueForTarget(Effect.EffectTarget.TargetItem02, SelectedEffectTargetType);
        }
        set
        {
            if (Effect.EffectTarget != null && value != null)
            {
                var newTargetItem02 = ConvertEnumToITargetType(value, SelectedEffectTargetType);

                if (!Equals(Effect.EffectTarget.TargetItem02, newTargetItem02))
                {
                    Effect.EffectTarget.TargetItem02 = newTargetItem02;
                    OnPropertyChanged(); // Aktualisiere die Property
                }
            }
        }
    }
    
    public Enum? SelectedEffectActivityConditionType
    {
        get
        {
            return GetEnumValueForActivity(Effect.EffectActivity.TargetItem02, SelectedEffectActivityType);
        }
        set
        {
            if (Effect.EffectActivity != null && value != null)
            {
                var newTargetItem02 = ConvertEnumToIActivityType(value, SelectedEffectActivityType);

                if (!Equals(Effect.EffectActivity.TargetItem02, newTargetItem02))
                {
                    Effect.EffectActivity.TargetItem02 = newTargetItem02;
                    OnPropertyChanged(); // Aktualisiere die Property
                }
            }
        }
    }

    public Enum? SelectedObjectActionConditionType
    {
        get
        {
            return Condition != null
                ? GetEnumValueForTarget(Condition.ObjectTarget.TargetItem02, SelectedObjectActionTargetType)
                : null;
        }
        set
        {
            if (Condition?.ObjectTarget != null && value != null)
            {
                var newTargetItem02 = ConvertEnumToITargetType(value, SelectedObjectActionTargetType);

                if (!Equals(Condition.ObjectTarget.TargetItem02, newTargetItem02))
                {
                    Condition.ObjectTarget.TargetItem02 = newTargetItem02;
                    OnPropertyChanged(); // Aktualisiere die Property
                }
            }
        }
    }

    public Enum? SelectedSubjectActionConditionType
    {
        get
        {
            // Hole den gespeicherten Wert aus TargetItem02, wenn vorhanden
            return Condition != null
                ? GetEnumValueForTarget(Condition.SubjectTarget.TargetItem02, SelectedSubjectActionTargetType)
                : null;
        }
        set
        {
            if (Condition?.SubjectTarget != null && value != null)
            {
                var newTargetItem02 = ConvertEnumToITargetType(value, SelectedSubjectActionTargetType);

                // Verhindere das Überschreiben, wenn der Wert bereits der gleiche ist
                if (!Equals(Condition.SubjectTarget.TargetItem02, newTargetItem02))
                {
                    Condition.SubjectTarget.TargetItem02 = newTargetItem02;
                    OnPropertyChanged(); // Aktualisiere die Property
                }
            }
        }
    }
    
    public Enum? SelectedActionActivityConditionType
    {
        get
        {
            // Hole den gespeicherten Wert aus TargetItem02, wenn vorhanden
            return Condition != null
                ? GetEnumValueForActivity(Condition.ConditionActivity.TargetItem02, SelectedActionActivityType)
                : null;
        }
        set
        {
            if (Condition?.ConditionActivity != null && value != null)
            {
                var newTargetItem02 = ConvertEnumToIActivityType(value, SelectedActionActivityType);

                // Verhindere das Überschreiben, wenn der Wert bereits der gleiche ist
                if (!Equals(Condition.ConditionActivity.TargetItem02, newTargetItem02))
                {
                    Condition.ConditionActivity.TargetItem02 = newTargetItem02;
                    OnPropertyChanged(); // Aktualisiere die Property
                }
            }
        }
    }
    
    private ITargetType ConvertEnumToITargetType(Enum enumValue, ActionTargetType targetType)
    {
        return targetType switch
        {
            ActionTargetType.ATT_TARGET_TYPE => new TargetTypeEnum((TargetType)enumValue),
            ActionTargetType.ATT_MOB_GRADE_TYPE => new MobGradeTypeEnum((MobGradeType)enumValue),
            ActionTargetType.ATT_MOB_TYPE => new MobTypeEnum((MobType)enumValue),
            ActionTargetType.ATT_CHARACTER_CLASS_TYPE => new CharacterClassTypeEnum((CharacterClassType)enumValue),
            _ => throw new InvalidOperationException($"Unsupported target type: {targetType}")
        };
    }
    
    private IActivityType ConvertEnumToIActivityType(Enum enumValue, ActionActivityType activityType)
    {
        return activityType switch
        {
            ActionActivityType.AAT_ATTACK_TYPE => new AttackTypeEnum((AttackType)enumValue),
            ActionActivityType.AAT_RECOVER_TYPE => new RecoverTypeEnum((RecoverType)enumValue),
            ActionActivityType.AAT_ABSTATE_INDEX => new AbstateIndexEnum((DummyType)enumValue),
            ActionActivityType.AAT_DISPEL_ATTRIBUTE => new DispelAttributeEnum((DispelAttribute)enumValue),
            ActionActivityType.AAT_TARGET_ACTION => new TargetActionEnum((TargetAction)enumValue),
            ActionActivityType.AAT_SKILL_EFFECT_INCREASE => new SkillEffectIncreaseEnum((SkillEffectIncreaseType)enumValue),
            ActionActivityType.AAT_ACTION_RANGE_TYPE => new ActionRangeEnum((ActionRangeType)enumValue),
            ActionActivityType.AAT_ACTIVE_SKILL_GROUP_INDEX => new ActiveSkillGroupIndexEnum((DummyType)enumValue),
            ActionActivityType.AAT_ACTION_ETC_TYPE => new ActionEquipEnum((ActionEquipType)enumValue),
            ActionActivityType.AAT_SET_ITEM_EFFECT_TYPE => new SetItemEffectEnum((SetItemEffectType)enumValue),
            _ => throw new InvalidOperationException($"Unsupported target type: {activityType}")
        };
    }

    private void UpdateEnumValues()
    {
        if (Condition == null)
        {
            ObjectActionConditionTypes.Clear();
            SubjectConditionTypes.Clear();
            ActivityTypes.Clear();
            EffectTargetTypes.Clear();
            EffectActivityTypes.Clear();
            return;
        }

        ObjectActionConditionTypes = GetEnumCollectionForTargetType(SelectedObjectActionTargetType);
        SubjectConditionTypes = GetEnumCollectionForTargetType(SelectedSubjectActionTargetType);
        ActivityTypes = GetEnumCollectionForActivityType(SelectedActionActivityType);
        EffectTargetTypes = GetEnumCollectionForTargetType(SelectedEffectTargetType);
        EffectActivityTypes = GetEnumCollectionForActivityType(SelectedEffectActivityType);

        SelectedObjectActionConditionType = GetEnumValueForTarget(Condition.ObjectTarget.TargetItem02,
            SelectedObjectActionTargetType);
        SelectedSubjectActionConditionType =
            GetEnumValueForTarget(Condition.SubjectTarget.TargetItem02,
                SelectedSubjectActionTargetType);
        SelectedActionActivityConditionType = GetEnumValueForActivity(Condition.ConditionActivity.TargetItem02,
            SelectedActionActivityType);
        SelectedEffectTargetConditionType =
            GetEnumValueForTarget(Effect.EffectTarget.TargetItem02, SelectedEffectTargetType);
        SelectedEffectActivityConditionType = GetEnumValueForActivity(Effect.EffectActivity.TargetItem02,
            SelectedEffectActivityType);
    }

    private void UpdateEnumValuesForSubject()
    {
        if (Condition == null)
        {
            SubjectConditionTypes.Clear();
            return;
        }

        SubjectConditionTypes = GetEnumCollectionForTargetType(SelectedSubjectActionTargetType);

        if (Condition.SubjectTarget.TargetItem02 == null)
        {
            Condition.SubjectTarget.TargetItem02 = GetDefaultEnumForTarget(SelectedSubjectActionTargetType)!;
        }

        SelectedSubjectActionConditionType = GetEnumValueForTarget(Condition.SubjectTarget.TargetItem02,
            SelectedSubjectActionTargetType);
    }
    
    private void UpdateEnumValuesForActivity()
    {
        if (Condition == null)
        {
            ActivityTypes.Clear();
            return;
        }

        ActivityTypes = GetEnumCollectionForActivityType(SelectedActionActivityType);

        if (Condition.ConditionActivity.TargetItem02 == null)
        {
            Condition.ConditionActivity.TargetItem02 = GetDefaultEnumForActivity(SelectedActionActivityType)!;
        }

        SelectedActionActivityConditionType = GetEnumValueForActivity(Condition.ConditionActivity.TargetItem02,
            SelectedActionActivityType);
    }


    private void UpdateEnumValuesForObject()
    {
        if (Condition == null)
        {
            ObjectActionConditionTypes.Clear();
            return;
        }

        ObjectActionConditionTypes = GetEnumCollectionForTargetType(SelectedObjectActionTargetType);

        if (Condition.ObjectTarget.TargetItem02 == null)
        {
            Condition.ObjectTarget.TargetItem02 = GetDefaultEnumForTarget(SelectedObjectActionTargetType)!;
        }

        SelectedObjectActionConditionType = GetEnumValueForTarget(Condition.ObjectTarget.TargetItem02,
            SelectedObjectActionTargetType);
    }
    
    private void UpdateEnumValuesForEffectTarget()
    {
        EffectTargetTypes = GetEnumCollectionForTargetType(SelectedEffectTargetType);

        if (Effect.EffectTarget.TargetItem02 == null)
        {
            Effect.EffectTarget.TargetItem02 = GetDefaultEnumForTarget(SelectedEffectTargetType)!;
        }

        SelectedEffectTargetConditionType = GetEnumValueForTarget(Effect.EffectTarget.TargetItem02,
            SelectedEffectTargetType);
    }
    
    private void UpdateEnumValuesForEffectActivity()
    {
        EffectActivityTypes = GetEnumCollectionForActivityType(SelectedEffectActivityType);

        if (Effect.EffectActivity.TargetItem02 == null)
        {
            Effect.EffectActivity.TargetItem02 = GetDefaultEnumForActivity(SelectedEffectActivityType)!;
        }

        SelectedEffectActivityConditionType = GetEnumValueForActivity(Effect.EffectActivity.TargetItem02,
            SelectedEffectActivityType);
    }

    private ITargetType? GetDefaultEnumForTarget(ActionTargetType targetType)
    {
        return targetType switch
        {
            ActionTargetType.ATT_TARGET_TYPE => new TargetTypeEnum(TargetType.TARGET_ENEMY),
            ActionTargetType.ATT_MOB_GRADE_TYPE => new MobGradeTypeEnum(MobGradeType.MGT_NORMAL),
            ActionTargetType.ATT_MOB_TYPE => new MobTypeEnum(MobType.MT_HUMAN),
            ActionTargetType.ATT_CHARACTER_CLASS_TYPE => new CharacterClassTypeEnum(CharacterClassType.CCT_FIGHTER),
            _ => null
        };
    }

    private ObservableCollection<Enum> GetEnumCollectionForTargetType(ActionTargetType targetType)
    {
        return targetType switch
        {
            ActionTargetType.ATT_TARGET_TYPE => new ObservableCollection<Enum>(Enum.GetValues(typeof(TargetType))
                .Cast<Enum>()),
            ActionTargetType.ATT_MOB_GRADE_TYPE => new ObservableCollection<Enum>(Enum.GetValues(typeof(MobGradeType))
                .Cast<Enum>()),
            ActionTargetType.ATT_MOB_TYPE => new ObservableCollection<Enum>(
                Enum.GetValues(typeof(MobType)).Cast<Enum>()),
            ActionTargetType.ATT_CHARACTER_CLASS_TYPE => new ObservableCollection<Enum>(
                Enum.GetValues(typeof(CharacterClassType)).Cast<Enum>()),
            _ => new ObservableCollection<Enum>()
        };
    }

    private Enum? GetEnumValueForTarget(ITargetType targetItem, ActionTargetType targetType)
    {
        return targetType switch
        {
            ActionTargetType.ATT_TARGET_TYPE => Enum.GetValues(typeof(TargetType)).Cast<Enum>()
                .FirstOrDefault(e => Convert.ToInt32(e) == targetItem.Value),
            ActionTargetType.ATT_MOB_GRADE_TYPE => Enum.GetValues(typeof(MobGradeType)).Cast<Enum>()
                .FirstOrDefault(e => Convert.ToInt32(e) == targetItem.Value),
            ActionTargetType.ATT_MOB_TYPE => Enum.GetValues(typeof(MobType)).Cast<Enum>()
                .FirstOrDefault(e => Convert.ToInt32(e) == targetItem.Value),
            ActionTargetType.ATT_CHARACTER_CLASS_TYPE => Enum.GetValues(typeof(CharacterClassType)).Cast<Enum>()
                .FirstOrDefault(e => Convert.ToInt32(e) == targetItem.Value),
            _ => null
        };
    }

    private IActivityType? GetDefaultEnumForActivity(ActionActivityType activityType)
    {
        return activityType switch
        {
            ActionActivityType.AAT_ATTACK_TYPE => new AttackTypeEnum(AttackType.AT_NORMAL),
            ActionActivityType.AAT_RECOVER_TYPE => new RecoverTypeEnum(RecoverType.RT_HPABSOLUTEPLUS),
            ActionActivityType.AAT_ABSTATE_INDEX => new AbstateIndexEnum(DummyType.DUMMY_TYPE_NONE0000),
            ActionActivityType.AAT_DISPEL_ATTRIBUTE => new DispelAttributeEnum(DispelAttribute.DA_POISON),
            ActionActivityType.AAT_TARGET_ACTION => new TargetActionEnum(TargetAction.TA_DIE),
            ActionActivityType.AAT_SKILL_EFFECT_INCREASE => new SkillEffectIncreaseEnum(SkillEffectIncreaseType.SEIT_DAMAGE_RATE_INCREASE),
            ActionActivityType.AAT_ACTION_RANGE_TYPE => new ActionRangeEnum(ActionRangeType.ART_LEVEL_0_19),
            ActionActivityType.AAT_ACTIVE_SKILL_GROUP_INDEX => new ActiveSkillGroupIndexEnum(DummyType.DUMMY_TYPE_NONE0000),
            ActionActivityType.AAT_ACTION_ETC_TYPE => new ActionEquipEnum(ActionEquipType.AET_ITEM_USE),
            ActionActivityType.AAT_SET_ITEM_EFFECT_TYPE => new SetItemEffectEnum(SetItemEffectType.SIET_DEFAULT),
            _ => null
        };
    }
    
    private ObservableCollection<Enum> GetEnumCollectionForActivityType(ActionActivityType activityType)
    {
        return activityType switch
        {
            ActionActivityType.AAT_ATTACK_TYPE => new ObservableCollection<Enum>(Enum.GetValues(typeof(AttackType)).Cast<Enum>()),
            ActionActivityType.AAT_RECOVER_TYPE => new ObservableCollection<Enum>(Enum.GetValues(typeof(RecoverType)).Cast<Enum>()),
            ActionActivityType.AAT_ABSTATE_INDEX => new ObservableCollection<Enum>(Enum.GetValues(typeof(DummyType)).Cast<Enum>()),
            ActionActivityType.AAT_DISPEL_ATTRIBUTE => new ObservableCollection<Enum>(Enum.GetValues(typeof(DispelAttribute)).Cast<Enum>()),
            ActionActivityType.AAT_TARGET_ACTION => new ObservableCollection<Enum>(Enum.GetValues(typeof(TargetAction)).Cast<Enum>()),
            ActionActivityType.AAT_SKILL_EFFECT_INCREASE => new ObservableCollection<Enum>(Enum.GetValues(typeof(SkillEffectIncreaseType)).Cast<Enum>()),
            ActionActivityType.AAT_ACTION_RANGE_TYPE => new ObservableCollection<Enum>(Enum.GetValues(typeof(ActionRangeType)).Cast<Enum>()),
            ActionActivityType.AAT_ACTIVE_SKILL_GROUP_INDEX => new ObservableCollection<Enum>(Enum.GetValues(typeof(DummyType)).Cast<Enum>()),
            ActionActivityType.AAT_ACTION_ETC_TYPE => new ObservableCollection<Enum>(Enum.GetValues(typeof(ActionEquipType)).Cast<Enum>()),
            ActionActivityType.AAT_SET_ITEM_EFFECT_TYPE => new ObservableCollection<Enum>(Enum.GetValues(typeof(SetItemEffectType)).Cast<Enum>()),
            _ => new ObservableCollection<Enum>()
        };
    }

    private Enum? GetEnumValueForActivity(IActivityType activityItem, ActionActivityType activityType)
    {
        return activityType switch
        {
            ActionActivityType.AAT_ATTACK_TYPE => Enum.GetValues(typeof(AttackType)).Cast<Enum>().FirstOrDefault(e => Convert.ToInt32(e) == activityItem.Value),
            ActionActivityType.AAT_RECOVER_TYPE => Enum.GetValues(typeof(RecoverType)).Cast<Enum>().FirstOrDefault(e => Convert.ToInt32(e) == activityItem.Value),
            ActionActivityType.AAT_ABSTATE_INDEX => Enum.GetValues(typeof(DummyType)).Cast<Enum>().FirstOrDefault(e => Convert.ToInt32(e) == activityItem.Value),
            ActionActivityType.AAT_DISPEL_ATTRIBUTE => Enum.GetValues(typeof(DispelAttribute)).Cast<Enum>().FirstOrDefault(e => Convert.ToInt32(e) == activityItem.Value),
            ActionActivityType.AAT_TARGET_ACTION => Enum.GetValues(typeof(TargetAction)).Cast<Enum>().FirstOrDefault(e => Convert.ToInt32(e) == activityItem.Value),
            ActionActivityType.AAT_SKILL_EFFECT_INCREASE => Enum.GetValues(typeof(SkillEffectIncreaseType)).Cast<Enum>().FirstOrDefault(e => Convert.ToInt32(e) == activityItem.Value),
            ActionActivityType.AAT_ACTION_RANGE_TYPE => Enum.GetValues(typeof(ActionRangeType)).Cast<Enum>().FirstOrDefault(e => Convert.ToInt32(e) == activityItem.Value),
            ActionActivityType.AAT_ACTIVE_SKILL_GROUP_INDEX => Enum.GetValues(typeof(DummyType)).Cast<Enum>().FirstOrDefault(e => Convert.ToInt32(e) == activityItem.Value),
            ActionActivityType.AAT_ACTION_ETC_TYPE => Enum.GetValues(typeof(ActionEquipType)).Cast<Enum>().FirstOrDefault(e => Convert.ToInt32(e) == activityItem.Value),
            ActionActivityType.AAT_SET_ITEM_EFFECT_TYPE => Enum.GetValues(typeof(SetItemEffectType)).Cast<Enum>().FirstOrDefault(e => Convert.ToInt32(e) == activityItem.Value),
            _ => null
        };
    }
}