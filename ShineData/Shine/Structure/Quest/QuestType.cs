// Copyright 2019 RED Software, LLC. All Rights Reserved.

using System.ComponentModel;

namespace ShineData.Shine.Structure.Quest
{
    public enum QuestType
    {
        [Description("Normal Quest")]
        QT_NORMAL = 0x0,
        [Description("Story Quest")]
        QT_STORY = 0x1,
        [Description("Class Quest")]
        QT_CLASS = 0x2,
        [Description("Event Quest")]
        QT_EVENT = 0x3,
        [Description("Instance Quest")]
        QT_INSTANCE_DUNGEON = 0x4,
        [Description("Normal Party Quest")]
        QT_NORMAL_PARTY = 0x5,
        [Description("Epic Quest")]
        QT_EPIC = 0x6,
        [Description("Epic Party Quest")]
        QT_EPIC_PARTY = 0x7,
        [Description("Raid Quest")]
        QT_RAID = 0x8,
        [Description("Chaos Quest")]
        QT_CHAO_QUEST = 0x9,
        [Description("Daily Quest")]
        QT_DAILY_QUEST = 0xA
    }
}
