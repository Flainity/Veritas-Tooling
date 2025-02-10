using ShineData.Shine.Structure.Enum;

namespace ShineData.Shine.Files;

public class SubAbState : IShineFile
{
    public ushort Id { get; set; }
    public string InxName { get; set; }
    public uint Strength { get; set; }
    public SubState Type { get; set; }
    public byte SubType { get; set; }
    public uint KeepTime { get; set; }
    public SubAbstateAction ActionIndex01 { get; set; }
    public uint ActionArg01 { get; set; }
    public SubAbstateAction ActionIndex02 { get; set; }
    public uint ActionArg02 { get; set; }
    public SubAbstateAction ActionIndex03 { get; set; }
    public uint ActionArg03 { get; set; }
    public SubAbstateAction ActionIndex04 { get; set; }
    public uint ActionArg04 { get; set; }
    
    public SubAbState() {}
    
    public SubAbState(ushort id, string inxName, uint strength, uint type, byte subType, uint keepTime, uint actionIndex01, uint actionArg01, uint actionIndex02, uint actionArg02, uint actionIndex03, uint actionArg03, uint actionIndex04, uint actionArg04)
    {
        Id = id;
        InxName = inxName;
        Strength = strength;
        Type = (SubState) type;
        SubType = subType;
        KeepTime = keepTime;
        ActionIndex01 = (SubAbstateAction) actionIndex01;
        ActionArg01 = actionArg01;
        ActionIndex02 = (SubAbstateAction) actionIndex02;
        ActionArg02 = actionArg02;
        ActionIndex03 = (SubAbstateAction) actionIndex03;
        ActionArg03 = actionArg03;
        ActionIndex04 = (SubAbstateAction) actionIndex04;
        ActionArg04 = actionArg04;
    }
}