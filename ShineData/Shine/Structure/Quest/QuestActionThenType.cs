// Copyright 2019 RED Software, LLC. All Rights Reserved.

using System.ComponentModel;

namespace ShineData.Shine.Structure.Quest
{
    public enum QuestActionThenType
    {
        [Description("None")]
        QUEST_ACTION_THEN_NONE = 0x0,
        [Description("Drop Item")]
        QUEST_ACTION_THEN_DROP_ITEM = 0x1,
        [Description("Play Scenario")]
        QUEST_ACTION_THEN_PLAY_SCENARIO = 0x2,
        [Description("Spawn Mob")]
        QUEST_ACTION_THEN_SPAWN_MOB = 0x3,
        [Description("Call Pinescript")]
        QUEST_ACTION_THEN_CALL_PS = 0x4
    }
}