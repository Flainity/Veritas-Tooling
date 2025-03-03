using ShineData.Shine.Structure.Enum.Action.Activity.Enum;

namespace ShineData.Shine.Structure.Enum.Action.Activity;

public class AbstateIndexEnum : IActivityType
{
    public uint Value => (uint) ActivityType;
    public readonly DummyType ActivityType;

    public AbstateIndexEnum(DummyType activityType)
    {
        ActivityType = activityType;
    }
}