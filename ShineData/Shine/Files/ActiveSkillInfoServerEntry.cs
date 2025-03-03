using ShineData.Shine.Structure.Enum;

namespace ShineData.Shine.Files;

public class ActiveSkillInfoServerEntry : IShineEntry
{
    public ushort Id { get; set; }
    public string InxName { get; set; }
    public byte UsualAttack { get; set; }
    public uint PhysicalHitRate { get; set; }
    public uint MagicHitRate { get; set; }
    public uint PhysicalSuccessRate { get; set; }
    public uint MagicSuccessRate { get; set; }
    public byte StaLevel { get; set; }
    public uint DamageIncreaseRate { get; set; }
    public ushort DamageIncreaseValue { get; set; }
    public SkillHitType HitType { get; set; }
    public byte ItemUseSkill { get; set; }
    public uint AggroPerDamage { get; set; }
    public uint AbsoluteAggro { get; set; }
    public byte AttackStart { get; set; }
    public byte AttackEnd { get; set; }
    public ushort SwingTime { get; set; }
    public ushort HitTime { get; set; }
    public byte AddSoul { get; set; }
    
    public ActiveSkillInfoServerEntry() {}
    
    public ActiveSkillInfoServerEntry(ushort id, string inxName, byte usualAttack, uint physicalHitRate, uint magicHitRate, 
        uint physicalSuccessRate, uint magicSuccessRate, byte staLevel, uint damageIncreaseRate, 
        ushort damageIncreaseValue, uint hitType, byte itemUseSkill, uint aggroPerDamage, 
        uint absoluteAggro, byte attackStart, byte attackEnd, ushort swingTime, ushort hitTime, byte addSoul)
    {
        Id = id;
        InxName = inxName;
        UsualAttack = usualAttack;
        PhysicalHitRate = physicalHitRate;
        MagicHitRate = magicHitRate;
        PhysicalSuccessRate = physicalSuccessRate;
        MagicSuccessRate = magicSuccessRate;
        StaLevel = staLevel;
        DamageIncreaseRate = damageIncreaseRate;
        DamageIncreaseValue = damageIncreaseValue;
        HitType = (SkillHitType)hitType;
        ItemUseSkill = itemUseSkill;
        AggroPerDamage = aggroPerDamage;
        AbsoluteAggro = absoluteAggro;
        AttackStart = attackStart;
        AttackEnd = attackEnd;
        SwingTime = swingTime;
        HitTime = hitTime;
        AddSoul = addSoul;
    }
}