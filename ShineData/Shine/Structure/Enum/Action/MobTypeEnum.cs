namespace ShineData.Shine.Structure.Enum.Action;

public class MobTypeEnum : ITargetType
{
    public uint Value => (uint) TargetType;
    public readonly MobType TargetType;

    public MobTypeEnum(MobType targetType)
    {
        TargetType = targetType;
    }
}