using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum;

public enum AbstateMemoryStruct : uint
{
    [Description("Normal")]
    AMS_ELEMENT_NORMAL = 1,
    [Description("Tick Routine")]
    AMS_TICK_ROUTINE = 2,
    [Description("Party Enchant")]
    AMS_PARTY_ENCHANT = 3,
    [Description("Rest Count")]
    AMS_REST_COUNT = 4,
    [Description("Polymorph")]
    AMS_POLYMORPH = 5,
    [Description("Each Tick Routine")]
    AMS_EACH_TICK_ROUTINE = 6,
    [Description("Hide")]
    AMS_HIDE = 7,
    [Description("Couple Party Enchant")]
    AMS_COUPLE_PARTY_ENCHANT = 8,
    [Description("Guild Academy Master")]
    AMS_GUILD_ACADEMY_MASTER_ENCHANT = 9,
    [Description("Reinforced Move")]
    AMS_REINFORCED_MOVE = 10,
    [Description("Element Recovery")]
    AMS_ELEMENT_RECOVERY = 11,
    [Description("Rest Count Health Rate")]
    AMS_REST_COUNT_HEALTH_RATE = 12,
}