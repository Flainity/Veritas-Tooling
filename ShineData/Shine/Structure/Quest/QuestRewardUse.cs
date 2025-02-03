// Copyright 2019 RED Software, LLC. All Rights Reserved.

using System.ComponentModel;

namespace ShineData.Shine.Structure.Quest
{
    public enum QuestRewardUse
    {
        [Description("Not Rewarded")]
        QRU_UNUSED = 0x0,
        [Description("Primary")]
        QRU_PRIMARY = 0x1,
        [Description("Selectable")]
        QRU_SELECTABLE = 0x2
    }
}
