namespace ShineData.Shine.Structure.Enum.Action;

public class MobGradeTypeEnum : ITargetType
{
    public uint Value => (uint) TargetType;
    public readonly MobGradeType TargetType;

    public MobGradeTypeEnum(MobGradeType targetType)
    {
        TargetType = targetType;
    }
}