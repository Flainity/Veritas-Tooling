using ShineData.Shine.Structure.Enum.Action.Activity.Enum;

namespace ShineData.Shine.Structure.Enum.Action.Activity;

public class TargetActionEnum : IActivityType
{
    public uint Value => (uint) ActivityType;
    public readonly TargetAction ActivityType;

    public TargetActionEnum(TargetAction activityType)
    {
        ActivityType = activityType;
    }
}