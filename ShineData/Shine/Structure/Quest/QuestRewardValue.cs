// Copyright 2019 RED Software, LLC. All Rights Reserved.

namespace ShineData.Shine.Structure.Quest
{
    public class QuestRewardValue
    {
        public long Experience { get; set; }
        public long Money { get; set; }
        public ushort ItemId { get; set; }
        public ushort ItemLot { get; set; }
        public int AbStateKeepTime { get; set; }
        public ushort AbstateId { get; set; }
        public byte AbStateStrength { get; set; }
        public int Fame { get; set; }
        public int PetId { get; set; }
        public byte MiniHouseId { get; set; }
        public byte TitleType { get; set; }
        public byte TitleElementNo { get; set; }
        public int KillPoints { get; set; }
    }
}
