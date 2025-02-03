// Copyright 2019 RED Software, LLC. All Rights Reserved.

using System.ComponentModel;

namespace ShineData.Shine.Structure.Quest
{
    public enum QuestNPCMobAction
    {
        [Description("Reward")]
        QNMA_REWARDER = 0,
        [Description("Kill")]
        QNMA_KILL = 1,
        [Description("Find")]
        QNMA_FIND = 2,
        [Description("Talk")]
        QNMA_TALK = 3
    }
}
