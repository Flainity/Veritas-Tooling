using ShineData.Shine.Structure.Enum;

namespace ShineData.Shine.Files;

public class AbstateMemory : IShineFile
{
    public uint AbstateIndex { get; set; }
    public AbstateMemoryStruct AbstateMemoryStruct { get; set; }
    public uint SubAbstateAction { get; set; }
    
    public AbstateMemory()
    {
        AbstateIndex = 0;
        AbstateMemoryStruct = new AbstateMemoryStruct();
        SubAbstateAction = 0;
    }
    
    public AbstateMemory(uint abstateIndex, uint abstateMemoryStruct, uint subAbstateAction)
    {
        AbstateIndex = abstateIndex;
        AbstateMemoryStruct = (AbstateMemoryStruct)abstateMemoryStruct;
        SubAbstateAction = subAbstateAction;
    }
}