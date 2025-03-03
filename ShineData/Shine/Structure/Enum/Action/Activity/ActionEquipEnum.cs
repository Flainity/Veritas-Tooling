using ShineData.Shine.Structure.Enum.Action.Activity.Enum;

namespace ShineData.Shine.Structure.Enum.Action.Activity;

public class ActionEquipEnum : IActivityType
{
    public uint Value => (uint) ActivityType;
    public readonly ActionEquipType ActivityType;

    public ActionEquipEnum(ActionEquipType activityType)
    {
        ActivityType = activityType;
    }
}