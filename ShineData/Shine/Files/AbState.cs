using ShineData.Shine.Structure.Enum;

namespace ShineData.Shine.Files;

public class AbState : IShineFile
{
    public ushort Id { get; set; }
    public string InxName { get; set; }
    public AbstateIndex AbstateIndex { get; set; }
    public uint KeepTimeRatio { get; set; }
    public byte KeepTimePower { get; set; }
    public byte StateGrade { get; set; }
    public string PartyState01 { get; set; }
    public string PartyState02 { get; set; }
    public string PartyState03 { get; set; }
    public string PartyState04 { get; set; }
    public string PartyState05 { get; set; }
    public uint PartyRange { get; set; }
    public uint PartyEnchantNumber { get; set; }
    public string SubAbstate { get; set; }
    public DispelAttribute DispelAttribute { get; set; }
    public SubDispelAttribute SubDispelAttribute { get; set; }
    public AbstateSaveType AbstateSaveType { get; set; }
    public string MainStateInx { get; set; }
    public byte Duplicate { get; set; }

    public AbState()
    {
        Id = 0;
        InxName = "Hello World";
        AbstateIndex = AbstateIndex.STA_BH_HELGA_NONE;
        KeepTimeRatio = 0;
        KeepTimePower = 0;
        StateGrade = 0;
        PartyState01 = "Hello World";
        PartyState02 = "Hello World";
        PartyState03 = "Hello World";
        PartyState04 = "Hello World";
        PartyState05 = "Hello World";
        PartyRange = 0;
        PartyEnchantNumber = 0;
        SubAbstate = "Hello World";
        DispelAttribute = DispelAttribute.DA_NONE;
        SubDispelAttribute = SubDispelAttribute.SDA_NONE;
        AbstateSaveType = AbstateSaveType.AST_NONE;
        MainStateInx = "Hello World";
        Duplicate = 0;
    }
    
    public AbState(ushort id, string inxName, uint abstateIndex, uint keepTimeRatio, byte keepTimePower, byte stateGrade, 
        string partyState01, string partyState02, string partyState03, string partyState04, string partyState05, 
        uint partyRange, uint partyEnchantNumber, string subAbstate, uint dispelAttribute, uint subDispelAttribute, 
        uint abstateSaveType, string mainStateInx, byte duplicate)
    {
        Id = id;
        InxName = inxName;
        AbstateIndex = (AbstateIndex)abstateIndex;
        KeepTimeRatio = keepTimeRatio;
        KeepTimePower = keepTimePower;
        StateGrade = stateGrade;
        PartyState01 = partyState01;
        PartyState02 = partyState02;
        PartyState03 = partyState03;
        PartyState04 = partyState04;
        PartyState05 = partyState05;
        PartyRange = partyRange;
        PartyEnchantNumber = partyEnchantNumber;
        SubAbstate = subAbstate;
        DispelAttribute = (DispelAttribute)dispelAttribute;
        SubDispelAttribute = (SubDispelAttribute)subDispelAttribute;
        AbstateSaveType = (AbstateSaveType)abstateSaveType;
        MainStateInx = mainStateInx;
        Duplicate = duplicate;
    }
}