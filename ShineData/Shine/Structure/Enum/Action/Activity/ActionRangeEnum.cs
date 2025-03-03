using ShineData.Shine.Structure.Enum.Action.Activity.Enum;

namespace ShineData.Shine.Structure.Enum.Action.Activity;

public class ActionRangeEnum : IActivityType
{
    public uint Value => (uint) ActivityType;
    public readonly ActionRangeType ActivityType;

    public ActionRangeEnum(ActionRangeType activityType)
    {
        ActivityType = activityType;
    }
}