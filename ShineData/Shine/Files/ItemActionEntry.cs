namespace ShineData.Shine.Files;

public class ItemActionEntry : IShineEntry
{
    public ushort Id { get; set; }
    public ushort ConditionId { get; set; }
    public ushort EffectId { get; set; }
    public uint CoolTime { get; set; }
    public ushort CoolGroupActionId { get; set; }
    public string Description { get; set; }
    public ushort PairNumber { get; set; }
    
    public ItemActionEntry() {}
    
    public ItemActionEntry(ushort id, ushort conditionId, ushort effectId, uint coolTime, ushort coolGroupActionId, string description, ushort pairNumber)
    {
        Id = id;
        ConditionId = conditionId;
        EffectId = effectId;
        CoolTime = coolTime;
        CoolGroupActionId = coolGroupActionId;
        Description = description;
        PairNumber = pairNumber;
    }

    public override string ToString()
    {
        return $"Pair0{PairNumber}";
    }
}