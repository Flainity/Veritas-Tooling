namespace ShineData.Shine.Structure.Enum.Action.Activity;

public class RecoverTypeEnum : IActivityType
{
    public uint Value => (uint) ActivityType;
    public readonly RecoverType ActivityType;

    public RecoverTypeEnum(RecoverType activityType)
    {
        ActivityType = activityType;
    }
}