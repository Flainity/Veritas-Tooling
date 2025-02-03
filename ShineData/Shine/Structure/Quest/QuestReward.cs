// Copyright 2019 RED Software, LLC. All Rights Reserved.

namespace ShineData.Shine.Structure.Quest
{
    public class QuestReward
    {
        public QuestRewardUse Use { get; set; } = QuestRewardUse.QRU_UNUSED;
        public QuestRewardType Type { get; set; } = QuestRewardType.QRT_EXPERIENCE;
        public QuestRewardValue Value { get; set; }

        public QuestReward()
        {
            Value = new QuestRewardValue();
        }
    }
}
