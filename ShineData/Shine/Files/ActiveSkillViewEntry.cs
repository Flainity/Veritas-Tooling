using ShineData.Shine.Structure.Enum;

namespace ShineData.Shine.Files;

public class ActiveSkillViewEntry : IShineEntry
{
    public ushort Id { get; set; }
    public string InxName { get; set; }
    public uint CancelCasting { get; set; }
    public byte TargetChange { get; set; }
    public uint IconIndex { get; set; }
    public string IconFile { get; set; }
    public uint Red { get; set; }
    public uint Green { get; set; }
    public uint Blue { get; set; }
    public CastingType CastingType { get; set; }
    public ActionType ActionType { get; set; }
    public string CastReadyAction { get; set; }
    public string CastAction { get; set; }
    public string SwingAction { get; set; }
    public uint ShotEffectSpeed { get; set; }
    public string ShotEffect { get; set; }
    public string ShotSound { get; set; }
    public string LastAction { get; set; }
    public string LastEffect { get; set; }
    public LastEffectPosition LastEffectPosition { get; set; }
    public string LastEffectSound { get; set; }
    public string LastAreaEffect { get; set; }
    public string LastAreaEffectWhen { get; set; }
    public string LastAeraEffectSound { get; set; }
    public string DotEffect { get; set; }
    public string DotEffectSound { get; set; }
    public string DotEffectLoop { get; set; }
    public string DotEffectLoopSound { get; set; }
    public string Description { get; set; }
    public uint MinimumLevel { get; set; }
    public string Function { get; set; }
    public byte HideHandItem { get; set; }
    public string RawDescription { get; set; }
    
    public ActiveSkillViewEntry() {}
    
    public ActiveSkillViewEntry(ushort id, string inxName, uint cancelCasting, byte targetChange, uint iconIndex, 
        string iconFile, uint red, uint green, uint blue, uint castingType, uint actionType, 
        string castReadyAction, string castAction, string swingAction, uint shotEffectSpeed, 
        string shotEffect, string shotSound, string lastAction, string lastEffect, 
        uint lastEffectPosition, string lastEffectSound, string lastAreaEffect, string lastAreaEffectWhen, 
        string lastAeraEffectSound, string dotEffect, string dotEffectSound, string dotEffectLoop, 
        string dotEffectLoopSound, string description, uint minimumLevel, string function, byte hideHandItem,
        string rawDescription)
    {
        Id = id;
        InxName = inxName;
        CancelCasting = cancelCasting;
        TargetChange = targetChange;
        IconIndex = iconIndex;
        IconFile = iconFile;
        Red = red;
        Green = green;
        Blue = blue;
        CastingType = (CastingType)castingType;
        ActionType = (ActionType)actionType;
        CastReadyAction = castReadyAction;
        CastAction = castAction;
        SwingAction = swingAction;
        ShotEffectSpeed = shotEffectSpeed;
        ShotEffect = shotEffect;
        ShotSound = shotSound;
        LastAction = lastAction;
        LastEffect = lastEffect;
        LastEffectPosition = (LastEffectPosition)lastEffectPosition;
        LastEffectSound = lastEffectSound;
        LastAreaEffect = lastAreaEffect;
        LastAreaEffectWhen = lastAreaEffectWhen;
        LastAeraEffectSound = lastAeraEffectSound;
        DotEffect = dotEffect;
        DotEffectSound = dotEffectSound;
        DotEffectLoop = dotEffectLoop;
        DotEffectLoopSound = dotEffectLoopSound;
        Description = description;
        MinimumLevel = minimumLevel;
        Function = function;
        HideHandItem = hideHandItem;
        RawDescription = rawDescription;
    }
}