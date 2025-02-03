// Copyright 2019 RED Software, LLC. All Rights Reserved.

using System.ComponentModel;

namespace ShineData.Shine.Structure.Quest
{
    public enum QuestRewardType
    {
        [Description("Experience")]
        QRT_EXPERIENCE = 0x0,
        [Description("Money")]
        QRT_MONEY = 0x1,
        [Description("Item")]
        QRT_ITEM = 0x2,
        [Description("Abstate")]
        QRT_ABSTATE = 0x3,
        [Description("Fame")]
        QRT_FAME = 0x4,
        [Description("Pet")]
        QRT_PET = 0x5,
        [Description("Mini House")]
        QRT_MINIHOUSE = 0x6,
        [Description("Title")]
        QRT_TITLE = 0x7,
        [Description("Killpoint")]
        QRT_KILLPOINT = 0x8
    }
}
