// Copyright 2019 RED Software, LLC. All Rights Reserved.

using System.ComponentModel;

namespace ShineData.Shine.Structure.Quest
{
    public enum QuestActionIfType
    {
        [Description("None")]
        QUEST_ACTION_IF_NONE = 0x0,
        [Description("Mob Kill")]
        QUEST_ACTION_IF_MOB_KILL = 0x1,
        [Description("Gather")]
        QUEST_ACTION_IF_GATHER = 0x2,
        [Description("Touch Object")]
        QUEST_ACTION_IF_TOUCH_OBJECT = 0x3,
        [Description("Area Info")]
        QUEST_ACTION_IF_AREAINFO = 0x4
    }
}
