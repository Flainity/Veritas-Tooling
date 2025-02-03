using System.Text;

namespace ShineData.Shine.Structure.Quest
{
    public class Quest
    {
        public ushort Id { get; set; }
        public int NameId { get; set; }
        public string Name { get; set; } = "Unnamed Quest";
        public int BriefId { get; set; }
        public byte Region { get; set; }
        public QuestType Type { get; set; } = QuestType.QT_NORMAL;
        public bool IsRepeatable { get; set; }
        public DailyQuestType DailyQuestType { get; set; } = DailyQuestType.DQT_NONE;
        public QuestStartCondition StartCondition { get; private set; } = new();
        public QuestEndCondition EndCondition { get; private set; } = new();
        public byte ActionCount { get; private set; }
        public QuestAction[] Actions { get; } = { new(), new(), new(), new(), new(), new(), new(), new(), new(), new() };
        public QuestReward[] Rewards { get; } = { new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new() };
        private ushort ScriptStartSize { get; set; }
        private ushort ScriptEndSize { get; set; }
        private ushort ScriptDoingSize { get; set; }
        public int StartScriptId { get; private set; }
        public int DoingScriptId { get; private set; }
        public int EndScriptId { get; private set; }
        public string StartScript { get; private set; } = "";
        public string DoingScript { get; private set; } = "";
        public string EndScript { get; private set; } = "";

        public static Quest Parse(byte[] data)
        {
            try
            {
                var quest = new Quest();
                using var reader = new BinaryReader(new MemoryStream(data));
                
                quest.Id = (ushort) reader.ReadInt32();
                quest.NameId = reader.ReadInt32();
                quest.BriefId = reader.ReadInt32();
                quest.Region = reader.ReadByte();
                quest.Type = (QuestType)reader.ReadByte();
                quest.IsRepeatable = reader.ReadBoolean();
                quest.DailyQuestType = (DailyQuestType)reader.ReadByte();
                reader.ReadBytes(4);

                // Start Condition
                quest.StartCondition = new QuestStartCondition
                {
                    IsWaitListView = reader.ReadBoolean(),
                    IsWaitListProgress = reader.ReadBoolean(),
                    RequiresLevel = reader.ReadBoolean(),
                    MinLevel = reader.ReadByte(),
                    MaxLevel = reader.ReadByte(),
                    RequiresNPC = reader.ReadBoolean(),
                    NPCID = reader.ReadUInt16(),
                    RequiresItem = reader.ReadBoolean()
                };
                
                reader.ReadBytes(1);
                quest.StartCondition.ItemID = reader.ReadUInt16();
                quest.StartCondition.ItemLot = reader.ReadUInt16();
                quest.StartCondition.RequiresLocation = reader.ReadBoolean();
                reader.ReadBytes(1);
                quest.StartCondition.LocationMapID = reader.ReadUInt16();
                reader.ReadBytes(2);
                quest.StartCondition.LocationX = reader.ReadInt32();
                quest.StartCondition.LocationY = reader.ReadInt32();
                quest.StartCondition.LocationRange = reader.ReadInt32();
                quest.StartCondition.RequiresQuest = reader.ReadBoolean();
                reader.ReadBytes(1);
                quest.StartCondition.QuestID = reader.ReadUInt16();
                quest.StartCondition.RequiresRace = reader.ReadBoolean();
                quest.StartCondition.Race = reader.ReadByte();
                quest.StartCondition.RequiresClass = reader.ReadBoolean();
                quest.StartCondition.Class = (CharacterClass) reader.ReadByte();
                quest.StartCondition.RequiresGender = reader.ReadBoolean();
                quest.StartCondition.Gender = (Gender)reader.ReadByte();
                quest.StartCondition.RequiresDateMode = reader.ReadBoolean();
                quest.StartCondition.DateMode = (QuestStartDateMode)reader.ReadByte();
                reader.ReadBytes(4);
                quest.StartCondition.StartDate = reader.ReadInt64();
                quest.StartCondition.EndDate = reader.ReadInt64();

                // End Condition
                quest.EndCondition = new QuestEndCondition
                {
                    IsWaitListProgress = reader.ReadBoolean(),
                    RequiresLevel = reader.ReadBoolean(),
                    Level = reader.ReadByte()
                };
                
                reader.ReadBytes(1);

                for (var i = 0; i < 5; i++)
                {
                    var npcMob = quest.EndCondition.NPCMobs[i];

                    npcMob.IsRequired = reader.ReadBoolean();
                    reader.ReadBytes(1);
                    npcMob.ID = reader.ReadUInt16();
                    npcMob.Action = (QuestNPCMobAction)reader.ReadByte();
                    npcMob.Count = reader.ReadByte();
                    npcMob.TargetGroup = (MobGroup)reader.ReadByte();
                    reader.ReadBytes(1);
                }

                for (var i = 0; i < 5; i++)
                {
                    var item = quest.EndCondition.Items[i];

                    item.IsRequired = reader.ReadBoolean();
                    reader.ReadBytes(1);
                    item.ID = reader.ReadUInt16();
                    item.Lot = reader.ReadUInt16();
                }

                quest.EndCondition.RequiresLocation = reader.ReadBoolean();
                reader.ReadBytes(1);
                quest.EndCondition.LocationMapID = reader.ReadUInt16();
                reader.ReadBytes(2);
                quest.EndCondition.LocationX = reader.ReadInt32();
                quest.EndCondition.LocationY = reader.ReadInt32();
                quest.EndCondition.LocationRange = reader.ReadInt32();
                quest.EndCondition.IsScenario = reader.ReadBoolean();
                reader.ReadBytes(1);
                quest.EndCondition.ScenarioID = reader.ReadUInt16();
                quest.EndCondition.RequiresRace = reader.ReadBoolean();
                quest.EndCondition.Race = reader.ReadByte();
                quest.EndCondition.RequiresClass = reader.ReadBoolean();
                quest.EndCondition.Class = (CharacterClass)reader.ReadByte();
                quest.EndCondition.IsTimeLimit = reader.ReadBoolean();
                reader.ReadBytes(1);
                quest.EndCondition.TimeLimit = reader.ReadUInt16();

                // Actions
                quest.ActionCount = reader.ReadByte();
                reader.ReadBytes(3);

                for (var i = 0; i < 10; i++)
                {
                    var action = quest.Actions[i];

                    action.IfType = (QuestActionIfType)reader.ReadByte();
                    reader.ReadBytes(3);
                    action.IfTarget = reader.ReadInt32();
                    action.ThenType = (QuestActionThenType)reader.ReadByte();
                    reader.ReadBytes(3);
                    action.ThenTarget = reader.ReadInt32();
                    action.ThenPercent = reader.ReadInt32();
                    action.ThenMinCount = reader.ReadInt32();
                    action.ThenMaxCount = reader.ReadInt32();
                    action.TargetGroup = (MobGroup)reader.ReadByte();
                    reader.ReadBytes(3);
                }

                // Rewards
                for (var i = 0; i < 12; i++)
                {
                    var reward = quest.Rewards[i];

                    reward.Use = (QuestRewardUse)reader.ReadByte();
                    reward.Type = (QuestRewardType)reader.ReadByte();
                    reader.ReadBytes(2);

                    switch (reward.Type)
                    {
                        case QuestRewardType.QRT_EXPERIENCE:
                            reward.Value.Experience = reader.ReadInt64();
                            break;
                        case QuestRewardType.QRT_MONEY:
                            reward.Value.Money = reader.ReadInt64();
                            break;
                        case QuestRewardType.QRT_ITEM:
                            reward.Value.ItemId = reader.ReadUInt16();
                            reward.Value.ItemLot = reader.ReadUInt16();
                            reader.ReadBytes(4);
                            break;
                        case QuestRewardType.QRT_ABSTATE:
                            reward.Value.AbStateKeepTime = reader.ReadInt32();
                            reward.Value.AbstateId = reader.ReadUInt16();
                            reward.Value.AbStateStrength = reader.ReadByte();
                            reader.ReadBytes(1);
                            break;
                        case QuestRewardType.QRT_FAME:
                            reward.Value.Fame = reader.ReadInt32();
                            reader.ReadBytes(4);
                            break;
                        case QuestRewardType.QRT_PET:
                            reward.Value.PetId = reader.ReadInt32();
                            reader.ReadBytes(4);
                            break;
                        case QuestRewardType.QRT_MINIHOUSE:
                            reward.Value.MiniHouseId = reader.ReadByte();
                            reader.ReadBytes(7);
                            break;
                        case QuestRewardType.QRT_TITLE:
                            reward.Value.TitleType = reader.ReadByte();
                            reward.Value.TitleElementNo = reader.ReadByte();
                            reader.ReadBytes(6);
                            break;
                        case QuestRewardType.QRT_KILLPOINT:
                            reward.Value.KillPoints = reader.ReadInt32();
                            reader.ReadBytes(4);
                            break;
                    }
                }

                quest.ScriptStartSize = reader.ReadUInt16();
                quest.ScriptEndSize = reader.ReadUInt16();
                quest.ScriptDoingSize = reader.ReadUInt16();
                reader.ReadUInt16();
                quest.StartScriptId = reader.ReadInt32();
                quest.DoingScriptId = reader.ReadInt32();
                quest.EndScriptId = reader.ReadInt32();
                quest.StartScript = Encoding.ASCII.GetString(reader.ReadBytes(quest.ScriptStartSize));
                quest.DoingScript = Encoding.ASCII.GetString(reader.ReadBytes(quest.ScriptDoingSize));
                quest.EndScript = Encoding.ASCII.GetString(reader.ReadBytes(quest.ScriptEndSize));

                quest.StartScript = quest.StartScript.Substring(0, Math.Max(0, quest.StartScript.IndexOf(char.MinValue)));
                quest.DoingScript = quest.DoingScript.Substring(0, Math.Max(0, quest.DoingScript.IndexOf(char.MinValue)));
                quest.EndScript = quest.EndScript.Substring(0, Math.Max(0, quest.EndScript.IndexOf(char.MinValue)));

                return quest;
            }
            catch (Exception e)
            {
                throw new Exception("Failed to parse quest.", e);
            }
        }
        
        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}