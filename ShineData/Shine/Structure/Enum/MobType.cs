using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum;

public enum MobType : uint
{
    [Description("Human")]
    MT_HUMAN,
    [Description("Magic Life")]
    MT_MAGICLIFE,
    [Description("Spirit")]
    MT_SPIRIT,
    [Description("Beast")]
    MT_BEAST,
    [Description("Elemental")]
    MT_ELEMENTAL,
    [Description("Undead")]
    MT_UNDEAD,
    [Description("NPC")]
    MT_NPC,
    [Description("Object")]
    MT_OBJECT,
    [Description("Mine")]
    MT_MINE,
    [Description("Herb")]
    MT_HERB,
    [Description("Wood")]
    MT_WOOD,
    [Description("No Name")]
    MT_NONAME,
    [Description("No Target")]
    MT_NOTARGET,
    [Description("No Target 2")]
    MT_NOTARGET2,
    [Description("Guild Item")]
    MT_GLDITEM,
    [Description("Flag")]
    MT_FLAG,
    [Description("Devil")]
    MT_DEVIL,
    [Description("Meta")]
    MT_META,
    [Description("No Damage")]
    MT_NODAMAGE,
    [Description("No Damage 2")]
    MT_NODAMAGE2,
    [Description("No Name Gate")]
    MT_NONAMEGATE,
    [Description("Box Herb")]
    MT_BOX_HERB,
    [Description("Box Mine")]
    MT_BOX_MINE,
    [Description("Lucky House Dice")]
    MT_GB_DICE,
    [Description("No Damage 3")]
    MT_NODAMAGE3,
    [Description("Friend")]
    MT_FRIEND,
    [Description("Slot Machine")]
    MT_GB_SLOTMACHINE,
    [Description("Friend Damage Absorb")]
    MT_FRIENDDMGABSORB,
    [Description("Devildom")]
    MT_DEVILDOM,
    [Description("No Target 3")]
    MT_NOTARGET3,
    [Description("Meta 2")]
    MT_META2,
    [Description("Dwarf")]
    MT_DWARF,
    [Description("Machine")]
    MT_MACHINE
}