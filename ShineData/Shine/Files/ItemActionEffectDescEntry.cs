namespace ShineData.Shine.Files;

public class ItemActionEffectDescEntry : IShineEntry
{
    public ushort Id { get; set; }
    public byte UseItem { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    
    public ItemActionEffectDescEntry() {}
    
    public ItemActionEffectDescEntry(ushort id, byte useItem, string description, string title)
    {
        Id = id;
        UseItem = useItem;
        Description = description;
        Title = title;
    }

    public override string ToString()
    {
        return $"{Id} - {Title}";
    }
}