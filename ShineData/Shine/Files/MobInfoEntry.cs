using ShineData.Shine.Attribute;
using ShineData.Shine.Structure.Enum;

namespace ShineData.Shine.Files;

public class MobInfoEntry : IShineEntry
{
    public ushort Id { get; set; }
    public string InxName { get; set; }
    public string Name { get; set; }
    public uint Level { get; set; }
    public uint MaximumHealth { get; set; }
    public uint WalkSpeed { get; set; }
    public uint RunSpeed { get; set; }
    public byte IsNPC { get; set; }
    public uint Size { get; set; }
    public WeaponType WeaponType { get; set; }
    public ArmorType ArmorType { get; set; }
    public MobGradeType GradeType { get; set; }
    public MobType Type { get; set; }
    public byte IsPlayerSide { get; set; }
    public uint AbsoluteSize { get; set; }
    
    public MobInfoEntry() {}
    
    public MobInfoEntry(ushort id, string inxName, string name, uint level, uint maximumHealth, uint walkSpeed, uint runSpeed, byte isNPC, uint size,
        uint weaponType, uint armorType, uint gradeType, uint type, byte isPlayerSide, uint absoluteSize)
    {
        Id = id;
        InxName = inxName;
        Name = name;
        Level = level;
        MaximumHealth = maximumHealth;
        WalkSpeed = walkSpeed;
        RunSpeed = runSpeed;
        IsNPC = isNPC;
        Size = size;
        WeaponType = (WeaponType)weaponType;
        ArmorType = (ArmorType)armorType;
        GradeType = (MobGradeType)gradeType;
        Type = (MobType)type;
        IsPlayerSide = isPlayerSide;
        AbsoluteSize = absoluteSize;
    }

    public override string ToString()
    {
        return InxName;
    }
}