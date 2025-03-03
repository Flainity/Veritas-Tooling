using ShineData.Shine.Structure.Enum.Action.Activity.Enum;

namespace ShineData.Shine.Structure.Enum.Action.Activity;

public class SetItemEffectEnum : IActivityType
{
    public uint Value => (uint) ActivityType;
    public readonly SetItemEffectType ActivityType;

    public SetItemEffectEnum(SetItemEffectType activityType)
    {
        ActivityType = activityType;
    }
}