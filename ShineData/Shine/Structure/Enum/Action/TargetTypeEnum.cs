namespace ShineData.Shine.Structure.Enum.Action;

public class TargetTypeEnum : ITargetType
{
    public uint Value => (uint) TargetType;
    public readonly TargetType TargetType;

    public TargetTypeEnum(TargetType targetType)
    {
        TargetType = targetType;
    }
}