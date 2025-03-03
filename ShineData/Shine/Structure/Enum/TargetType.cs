using System.ComponentModel;
using ShineData.Shine.Attribute;

namespace ShineData.Shine.Structure.Enum;

public enum TargetType : uint
{
    [Description("Enemy")]
    TARGET_ENEMY,
    [Explanation("Player")]
    [Description("Self")]
    TARGET_ME,
    [Description("Party")]
    TARGET_PARTY,
    [Description("Friend")]
    TARGET_FRIEND,
    [Description("Spot")]
    TARGET_SPOT,
    [Description("All")]
    TARGET_ALL,
    [Description("Group")]
    TARGET_GROUP,
    [Description("Enemy Player")]
    TARGET_ENEMYUSER,
    [Description("Everything")]
    TARGET_EVERY,
    [Description("Enemy Guild")]
    TARGET_ENEMYGUILD,
    [Description("Own Guild")]
    TARGET_MYGUILD,
    [Description("Own NPC")]
    TARGET_MYNPC,
    [Description("Own Raid")]
    TARGET_MYRAID,
    [Description("Box")]
    TARGET_BOX,
    [Description("This Action")]
    TARGET_THISACTION,
    [Description("Attack Self")]
    TARGET_ATTACKME,
    [Description("Damage by Self")]
    TARGET_DAMAGEBYME,
    [Description("This Skill")]
    TARGET_THISSKILL,
    [Description("None")]
    TARGET_NONE
}