using ShineData.Shine.Structure.Enum;

namespace ShineData.Shine.Files;

public class ActiveSkillEntry : IShineEntry
{
    public ushort Id { get; set; }
    public string InxName { get; set; }
    public string Name { get; set; }
    public uint Grade { get; set; }
    public uint Step { get; set; }
    public uint MaxStep { get; set; }
    public WeaponDemandType WeaponDemandType { get; set; }
    public string DemandSkill { get; set; }
    public ushort UseItem { get; set; }
    public uint ItemNumber { get; set; }
    public uint ItemOption { get; set; }
    public ushort DemandItem01 { get; set; }
    public ushort DemandItem02 { get; set; }
    public uint Mana { get; set; }
    public uint ManaRate { get; set; }
    public uint Health { get; set; }
    public uint HealthRate { get; set; }
    public uint LightPoint { get; set; }
    public uint Range { get; set; }
    public TargetType FirstTarget { get; set; }
    public TargetType LastTarget { get; set; }
    public byte IsMovingSkill { get; set; }
    public ushort UsableDegree { get; set; }
    public ushort DirectionRotate { get; set; }
    public ushort SkillDegree { get; set; }
    public TargetState TargetState { get; set; }
    public uint CastTime { get; set; }
    public uint DelayTime { get; set; }
    public uint DelayGroupNumber { get; set; }
    public uint DelayTimeGroup { get; set; }
    public uint MinimumDamage { get; set; }
    public uint MinimumDamageRate { get; set; }
    public uint MaximumDamage { get; set; }
    public uint MaximumDamageRate { get; set; }
    public uint MinimumMagicDamage { get; set; }
    public uint MinimumMagicDamageRate { get; set; }
    public uint MaximumMagicDamage { get; set; }
    public uint MaximumMagicDamageRate { get; set; }
    public uint Defense { get; set; }
    public uint MagicResistance { get; set; }
    public uint Area { get; set; }
    public uint TargetCount { get; set; }
    public UseClassType UseClassType { get; set; }
    public string AbstateName01 { get; set; }
    public uint AbstateStrength01 { get; set; }
    public uint AbstateRate01 { get; set; }
    public string AbstateName02 { get; set; }
    public uint AbstateStrength02 { get; set; }
    public uint AbstateRate02 { get; set; }
    public string AbstateName03 { get; set; }
    public uint AbstateStrength03 { get; set; }
    public uint AbstateRate03 { get; set; }
    public string AbstateName04 { get; set; }
    public uint AbstateStrength04 { get; set; }
    public uint AbstateRate04 { get; set; }
    public int StrengthIncreaseMaxPoints { get; set; }
    public int ManaConsumptionDecreaseMaxPoints { get; set; }
    public int EffectTimeIncreaseMaxPoints { get; set; }
    public int CooldownDecreaseMaxPoints { get; set; }
    public int StrengthIncrease01 { get; set; }
    public int StrengthIncrease02 { get; set; }
    public int StrengthIncrease03 { get; set; }
    public int StrengthIncrease04 { get; set; }
    public int StrengthIncrease05 { get; set; }
    public int ManaConsumptionDecrease01 { get; set; }
    public int ManaConsumptionDecrease02 { get; set; }
    public int ManaConsumptionDecrease03 { get; set; }
    public int ManaConsumptionDecrease04 { get; set; }
    public int ManaConsumptionDecrease05 { get; set; }
    public int EffectTimeIncrease01 { get; set; }
    public int EffectTimeIncrease02 { get; set; }
    public int EffectTimeIncrease03 { get; set; }
    public int EffectTimeIncrease04 { get; set; }
    public int EffectTimeIncrease05 { get; set; }
    public int CooldownDecrease01 { get; set; }
    public int CooldownDecrease02 { get; set; }
    public int CooldownDecrease03 { get; set; }
    public int CooldownDecrease04 { get; set; }
    public int CooldownDecrease05 { get; set; }
    public SkillEffectType SkillEffectType { get; set; }
    public SkillSpecial SpecialIndex01 { get; set; }
    public uint SpecialValue01 { get; set; }
    public SkillSpecial SpecialIndex02 { get; set; }
    public uint SpecialValue02 { get; set; }
    public SkillSpecial SpecialIndex03 { get; set; }
    public uint SpecialValue03 { get; set; }
    public SkillSpecial SpecialIndex04 { get; set; }
    public uint SpecialValue04 { get; set; }
    public SkillSpecial SpecialIndex05 { get; set; }
    public uint SpecialValue05 { get; set; }
    public string SkillClassifier01 { get; set; }
    public string SkillClassifier02 { get; set; }
    public string SkillClassifier03 { get; set; }
    public byte CannotInside { get; set; }
    public byte DemandSoul { get; set; }
    public ushort HitId { get; set; }
    
    public ActiveSkillEntry() {}

    public ActiveSkillEntry(ushort id, string inxName, string name, uint grade, uint step, uint maxStep,
        uint weaponDemandType,
        string demandSkill, ushort useItem, uint itemNumber, uint itemOption, ushort demandItem01, ushort demandItem02,
        uint mana, uint manaRate, uint health, uint healthRate, uint lightPoint, uint range, uint firstTarget,
        uint lastTarget, byte isMovingSkill, ushort usableDegree, ushort directionRotate, ushort skillDegree,
        uint targetState, uint castTime, uint delayTime, uint delayGroupNumber, uint delayTimeGroup,
        uint minimumDamage, uint minimumDamageRate, uint maximumDamage, uint maximumDamageRate, uint minimumMagicDamage,
        uint minimumMagicDamageRate, uint maximumMagicDamage, uint maximumMagicDamageRate, uint defense,
        uint magicResistance,
        uint area, uint targetCount, uint useClassType, string abstateName01, uint abstateStrength01,
        uint abstateRate01,
        string abstateName02, uint abstateStrength02, uint abstateRate02, string abstateName03, uint abstateStrength03,
        uint abstateRate03, string abstateName04, uint abstateStrength04, uint abstateRate04, int strengthIncreaseMaxPoints,
        int manaConsumptionDecreaseMaxPoints, int effectTimeIncreaseMaxPoints, int cooldownDecreaseMaxPoints,
        int strengthIncrease01, int strengthIncrease02, int strengthIncrease03, int strengthIncrease04, int strengthIncrease05, 
        int manaConsumptionDecrease01, int manaConsumptionDecrease02, int manaConsumptionDecrease03, int manaConsumptionDecrease04, int manaConsumptionDecrease05, 
        int effectTimeIncrease01, int effectTimeIncrease02, int effectTimeIncrease03, int effectTimeIncrease04, int effectTimeIncrease05, 
        int cooldownDecrease01, int cooldownDecrease02, int cooldownDecrease03, int cooldownDecrease04, int cooldownDecrease05, 
        uint skillEffectType, uint specialIndex01, uint specialValue01,
        uint specialIndex02, uint specialValue02, uint specialIndex03, uint specialValue03,
        uint specialIndex04, uint specialValue04, uint specialIndex05, uint specialValue05,
        string skillClassifier01, string skillClassifier02, string skillClassifier03, byte cannotInside,
        byte demandSoul, ushort hitId)
    {
        Id = id;
        InxName = inxName;
        Name = name;
        Grade = grade;
        Step = step;
        MaxStep = maxStep;
        WeaponDemandType = (WeaponDemandType) weaponDemandType;
        DemandSkill = demandSkill;
        UseItem = useItem;
        ItemNumber = itemNumber;
        ItemOption = itemOption;
        DemandItem01 = demandItem01;
        DemandItem02 = demandItem02;
        Mana = mana;
        ManaRate = manaRate;
        Health = health;
        HealthRate = healthRate;
        LightPoint = lightPoint;
        Range = range;
        FirstTarget = (TargetType) firstTarget;
        LastTarget = (TargetType) lastTarget;
        IsMovingSkill = isMovingSkill;
        UsableDegree = usableDegree;
        DirectionRotate = directionRotate;
        SkillDegree = skillDegree;
        TargetState = (TargetState) targetState;
        CastTime = castTime;
        DelayTime = delayTime;
        DelayGroupNumber = delayGroupNumber;
        DelayTimeGroup = delayTimeGroup;
        MinimumDamage = minimumDamage;
        MinimumDamageRate = minimumDamageRate;
        MaximumDamage = maximumDamage;
        MaximumDamageRate = maximumDamageRate;
        MinimumMagicDamage = minimumMagicDamage;
        MinimumMagicDamageRate = minimumMagicDamageRate;
        MaximumMagicDamage = maximumMagicDamage;
        MaximumMagicDamageRate = maximumMagicDamageRate;
        Defense = defense;
        MagicResistance = magicResistance;
        Area = area;
        TargetCount = targetCount;
        UseClassType = (UseClassType) useClassType;
        AbstateName01 = abstateName01;
        AbstateStrength01 = abstateStrength01;
        AbstateRate01 = abstateRate01;
        AbstateName02 = abstateName02;
        AbstateStrength02 = abstateStrength02;
        AbstateRate02 = abstateRate02;
        AbstateName03 = abstateName03;
        AbstateStrength03 = abstateStrength03;
        AbstateRate03 = abstateRate03;
        AbstateName04 = abstateName04;
        AbstateStrength04 = abstateStrength04;
        AbstateRate04 = abstateRate04;
        StrengthIncreaseMaxPoints = strengthIncreaseMaxPoints;
        ManaConsumptionDecreaseMaxPoints = manaConsumptionDecreaseMaxPoints;
        EffectTimeIncreaseMaxPoints = effectTimeIncreaseMaxPoints;
        CooldownDecreaseMaxPoints = cooldownDecreaseMaxPoints;
        StrengthIncrease01 = strengthIncrease01;
        StrengthIncrease02 = strengthIncrease02;
        StrengthIncrease03 = strengthIncrease03;
        StrengthIncrease04 = strengthIncrease04;
        StrengthIncrease05 = strengthIncrease05;
        ManaConsumptionDecrease01 = manaConsumptionDecrease01;
        ManaConsumptionDecrease02 = manaConsumptionDecrease02;
        ManaConsumptionDecrease03 = manaConsumptionDecrease03;
        ManaConsumptionDecrease04 = manaConsumptionDecrease04;
        ManaConsumptionDecrease05 = manaConsumptionDecrease05;
        EffectTimeIncrease01 = effectTimeIncrease01;
        EffectTimeIncrease02 = effectTimeIncrease02;
        EffectTimeIncrease03 = effectTimeIncrease03;
        EffectTimeIncrease04 = effectTimeIncrease04;
        EffectTimeIncrease05 = effectTimeIncrease05;
        CooldownDecrease01 = cooldownDecrease01;
        CooldownDecrease02 = cooldownDecrease02;
        CooldownDecrease03 = cooldownDecrease03;
        CooldownDecrease04 = cooldownDecrease04;
        CooldownDecrease05 = cooldownDecrease05;
        SkillEffectType = (SkillEffectType) skillEffectType;
        SpecialIndex01 = (SkillSpecial) specialIndex01;
        SpecialValue01 = specialValue01;
        SpecialIndex02 = (SkillSpecial) specialIndex02;
        SpecialValue02 = specialValue02;
        SpecialIndex03 = (SkillSpecial) specialIndex03;
        SpecialValue03 = specialValue03;
        SpecialIndex04 = (SkillSpecial) specialIndex04;
        SpecialValue04 = specialValue04;
        SpecialIndex05 = (SkillSpecial) specialIndex05;
        SpecialValue05 = specialValue05;
        SkillClassifier01 = skillClassifier01;
        SkillClassifier02 = skillClassifier02;
        SkillClassifier03 = skillClassifier03;
        CannotInside = cannotInside;
        DemandSoul = demandSoul;
        HitId = hitId;
    }

    public override string ToString()
    {
        var index = Name.IndexOf(" [");
        return index >= 0 ? Name[..index] : Name;
    }
}