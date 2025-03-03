using ShineData.Shine.Structure.Enum;

namespace ShineData.Shine.Files;

public class AbStateViewEntry : IShineEntry
{
    public ushort Id { get; set; }
    public string InxName { get; set; }
    public uint Icon { get; set; }
    public string IconFile { get; set; }
    public string Description { get; set; }
    public byte Red { get; set; }
    public byte Green { get; set; }
    public byte Blue { get; set; }
    public string AnimationIndex { get; set; }
    public string EffectName { get; set; }
    public EffectPosition EffectNamePosition { get; set; }
    public byte EffectRefresh { get; set; }
    public string LoopEffect { get; set; }
    public EffectPosition LoopEffectPosition { get; set; }
    public string LastEffect { get; set; }
    public EffectPosition LastEffectPosition { get; set; }
    public string DamageOverTimeEffect { get; set; }
    public EffectPosition DamageOverTimeEffectPosition { get; set; }
    public string IconSort { get; set; }
    public StateType TypeSort { get; set; }
    public byte View { get; set; }
    
    public AbStateViewEntry() {}
    
    public AbStateViewEntry(ushort id, string inxName, uint icon, string iconFile, string description, byte red, 
        byte green, byte blue, string animationIndex, string effectName, uint effectNamePosition, 
        byte effectRefresh, string loopEffect, uint loopEffectPosition, string lastEffect, 
        uint lastEffectPosition, string damageOverTimeEffect, uint damageOverTimeEffectPosition, 
        string iconSort, uint typeSort, byte view)
    {
        Id = id;
        InxName = inxName;
        Icon = icon;
        IconFile = iconFile;
        Description = description;
        Red = red;
        Green = green;
        Blue = blue;
        AnimationIndex = animationIndex;
        EffectName = effectName;
        EffectNamePosition = (EffectPosition)effectNamePosition;
        EffectRefresh = effectRefresh;
        LoopEffect = loopEffect;
        LoopEffectPosition = (EffectPosition)loopEffectPosition;
        LastEffect = lastEffect;
        LastEffectPosition = (EffectPosition)lastEffectPosition;
        DamageOverTimeEffect = damageOverTimeEffect;
        DamageOverTimeEffectPosition = (EffectPosition)damageOverTimeEffectPosition;
        IconSort = iconSort;
        TypeSort = (StateType)typeSort;
        View = view;
    }
}