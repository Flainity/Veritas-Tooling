// Copyright 2019 RED Software, LLC. All Rights Reserved.

using System.ComponentModel;

namespace ShineData.Shine.Structure.Quest
{
    public enum DailyQuestType
    {
        [Description("None")]
        DQT_NONE = 0,
        [Description("Daily")]
        DQT_DAY = 1,
        [Description("Weekly")]
        DQT_WEEK = 2,
        [Description("Monthly")]
        DQT_MONTH = 3,
        [Description("Yearly")]
        DQT_YEAR = 4
    }
}
