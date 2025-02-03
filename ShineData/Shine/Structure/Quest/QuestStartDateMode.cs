// Copyright 2019 RED Software, LLC. All Rights Reserved.

using System.ComponentModel;

namespace ShineData.Shine.Structure.Quest
{
    public enum QuestStartDateMode
    {
        [Description("Year")]
        QSDM_YEAR = 0x0,
        [Description("Month")]
        QSDM_MONTH = 0x1,
        [Description("Date")]
        QSDM_DATE = 0x2,
        [Description("Period")]
        QSDM_PERIOD = 0x3
    }
}
