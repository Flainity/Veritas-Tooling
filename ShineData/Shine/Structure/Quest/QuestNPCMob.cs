// Copyright 2019 RED Software, LLC. All Rights Reserved.

namespace ShineData.Shine.Structure.Quest
{
    public class QuestNPCMob
    {
        public bool IsRequired { get; set; }
        public ushort ID { get; set; }
        public QuestNPCMobAction Action { get; set; } = QuestNPCMobAction.QNMA_REWARDER;
        public byte Count { get; set; }
        public MobGroup TargetGroup { get; set; }
    }
}
