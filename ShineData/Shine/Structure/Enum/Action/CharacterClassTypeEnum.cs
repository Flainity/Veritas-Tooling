namespace ShineData.Shine.Structure.Enum.Action;

public class CharacterClassTypeEnum : ITargetType
{
    public uint Value => (uint) TargetType;
    public readonly CharacterClassType TargetType;

    public CharacterClassTypeEnum(CharacterClassType targetType)
    {
        TargetType = targetType;
    }
}