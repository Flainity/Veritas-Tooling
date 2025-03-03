namespace ShineData.Shine.Structure.Enum.Action.Activity;

public class AttackTypeEnum : IActivityType
{
    public uint Value => (uint) ActivityType;
    public readonly AttackType ActivityType;

    public AttackTypeEnum(AttackType activityType)
    {
        ActivityType = activityType;
    }
}