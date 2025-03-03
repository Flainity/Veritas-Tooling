using ShineData.Shine.Structure.Enum.Action.Activity.Enum;

namespace ShineData.Shine.Structure.Enum.Action.Activity;

public class ActiveSkillGroupIndexEnum : IActivityType
{
    public uint Value => (uint) ActivityType;
    public readonly DummyType ActivityType;

    public ActiveSkillGroupIndexEnum(DummyType activityType)
    {
        ActivityType = activityType;
    }
}