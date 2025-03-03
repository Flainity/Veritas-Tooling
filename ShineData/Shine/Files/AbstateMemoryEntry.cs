using ShineData.Shine.Structure.Enum;

namespace ShineData.Shine.Files;

public class AbstateMemoryEntry : IShineEntry
{
    public uint AbstateIndex { get; set; }
    public AbstateMemoryStruct AbstateMemoryStruct { get; set; }
    public uint SubAbstateAction { get; set; }
    
    public AbstateMemoryEntry()
    {
        AbstateIndex = 0;
        AbstateMemoryStruct = new AbstateMemoryStruct();
        SubAbstateAction = 0;
    }
    
    public AbstateMemoryEntry(uint abstateIndex, uint abstateMemoryStruct, uint subAbstateAction)
    {
        AbstateIndex = abstateIndex;
        AbstateMemoryStruct = (AbstateMemoryStruct)abstateMemoryStruct;
        SubAbstateAction = subAbstateAction;
    }
}