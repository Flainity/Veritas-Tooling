namespace ShineData.Shine.Structure.Enum.Action.Activity;

public class SkillEffectIncreaseEnum : IActivityType
{
    public uint Value => (uint) ActivityType;
    public readonly SkillEffectIncreaseType ActivityType;

    public SkillEffectIncreaseEnum(SkillEffectIncreaseType activityType)
    {
        ActivityType = activityType;
    }
}