namespace ShineData.Shine.Structure.Enum.Action.Activity;

public class DispelAttributeEnum : IActivityType
{
    public uint Value => (uint) ActivityType;
    public readonly DispelAttribute ActivityType;

    public DispelAttributeEnum(DispelAttribute activityType)
    {
        ActivityType = activityType;
    }
}