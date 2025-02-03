using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Questy.Message;
using Questy.Service;
using ShineData.Shine.Extension;
using ShineData.Shine.Structure.Quest;

namespace Questy.ViewModel;

public partial class MainWindowViewModel : ObservableObject, IRecipient<QuestSelectionChangedMessage>
{
    [ObservableProperty] private QuestScriptViewModel _startScriptViewModel;
    [ObservableProperty] private QuestScriptViewModel _doingScriptViewModel;
    [ObservableProperty] private QuestScriptViewModel _endScriptViewModel;
    [ObservableProperty] private string _informationText = "Welcome to Questy!";
    
    private Quest? _selectedQuest;

    public MainWindowViewModel()
    {
        StartScriptViewModel = new QuestScriptViewModel();
        DoingScriptViewModel = new QuestScriptViewModel();
        EndScriptViewModel = new QuestScriptViewModel();
        WeakReferenceMessenger.Default.Register(this);
    }

    public void Receive(QuestSelectionChangedMessage message)
    {
        var selectedQuest = message.Value;
        _selectedQuest = selectedQuest;
        StartScriptViewModel.ScriptText = selectedQuest?.StartScript;
        DoingScriptViewModel.ScriptText = selectedQuest?.DoingScript;
        EndScriptViewModel.ScriptText = selectedQuest?.EndScript;
    }

    [RelayCommand]
    private Task NewQuest()
    {
        if (QuestService.Instance.QuestList.Count == 0)
        {
            MessageBox.Show("Please open the quest data file first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return Task.CompletedTask;
        }

        var newId = (ushort) (QuestService.Instance.QuestList.OrderBy(q => q.Id).LastOrDefault()?.Id + 1 ?? 1);
        var quest = new Quest {Id = newId, NameId = 0};

        QuestService.Instance.QuestList.Add(quest);
        InformationText = $"New quest created with ID {newId}";
        
        return Task.CompletedTask;
    }

    [RelayCommand]
    private Task DeleteQuest()
    {
        if (QuestService.Instance.QuestList.Count == 0)
        {
            MessageBox.Show("Please open the quest data file first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return Task.CompletedTask;
        }

        if (_selectedQuest == null) return Task.CompletedTask;
        
        var result = MessageBox.Show($"Are you sure you want to delete the quest \"{_selectedQuest.Name}\"?", "Delete Quest", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result != MessageBoxResult.Yes) return Task.CompletedTask;
        
        QuestService.Instance.QuestList.Remove(_selectedQuest);
        InformationText = $"Quest \"{_selectedQuest.Name}\" has been deleted.";
        _selectedQuest = QuestService.Instance.QuestList.FirstOrDefault();
        WeakReferenceMessenger.Default.Send(new QuestSelectionChangedMessage(_selectedQuest));

        return Task.CompletedTask;
    }

    [RelayCommand]
    private Task SaveQuestData()
    {
        var questData = QuestService.Instance;

        using var stream = new MemoryStream();
        using var writer = new BinaryWriter(stream);

        writer.Write(questData.QuestDataHeader);
        writer.Write((ushort) questData.QuestList.Count);

        foreach (var quest in questData.QuestList)
        {
            var lengthPosition = stream.Position;
            var startLength = stream.Length;

            writer.Write(0);
            writer.Write((int) quest.Id);
            writer.Write(quest.NameId);
            writer.Write(quest.BriefId);
            writer.Write(quest.Region);
            writer.Write((byte) quest.Type);
            writer.Write(quest.IsRepeatable);
            writer.Write((byte) quest.DailyQuestType);
            writer.Fill(4);

            // Start Condition
            writer.Write(quest.StartCondition.IsWaitListView);
            writer.Write(quest.StartCondition.IsWaitListProgress);
            writer.Write(quest.StartCondition.RequiresLevel);
            writer.Write(quest.StartCondition.MinLevel);
            writer.Write(quest.StartCondition.MaxLevel);
            writer.Write(quest.StartCondition.RequiresNPC);
            writer.Write(quest.StartCondition.NPCID);
            writer.Write(quest.StartCondition.RequiresItem);
            writer.Fill(1);
            writer.Write(quest.StartCondition.ItemID);
            writer.Write(quest.StartCondition.ItemLot);
            writer.Write(quest.StartCondition.RequiresLocation);
            writer.Fill(1);
            writer.Write(quest.StartCondition.LocationMapID);
            writer.Fill(2);
            writer.Write(quest.StartCondition.LocationX);
            writer.Write(quest.StartCondition.LocationY);
            writer.Write(quest.StartCondition.LocationRange);
            writer.Write(quest.StartCondition.RequiresQuest);
            writer.Fill(1);
            writer.Write(quest.StartCondition.QuestID);
            writer.Write(quest.StartCondition.RequiresRace);
            writer.Write(quest.StartCondition.Race);
            writer.Write(quest.StartCondition.RequiresClass);
            writer.Write((byte) quest.StartCondition.Class);
            writer.Write(quest.StartCondition.RequiresGender);
            writer.Write((byte) quest.StartCondition.Gender);
            writer.Write(quest.StartCondition.RequiresDateMode);
            writer.Write((byte) quest.StartCondition.DateMode);
            writer.Fill(4);
            writer.Write(quest.StartCondition.StartDate);
            writer.Write(quest.StartCondition.EndDate);

            writer.Write(quest.EndCondition.IsWaitListProgress);
            writer.Write(quest.EndCondition.RequiresLevel);
            writer.Write(quest.EndCondition.Level);
            writer.Fill(1);

            for (var i = 0; i < 5; i++)
            {
                var mob = quest.EndCondition.NPCMobs[i];

                writer.Write(mob.IsRequired);
                writer.Fill(1);
                writer.Write(mob.ID);
                writer.Write((byte) mob.Action);
                writer.Write(mob.Count);
                writer.Write((byte) mob.TargetGroup);
                writer.Fill(1);
            }

            for (var i = 0; i < 5; i++)
            {
                var item = quest.EndCondition.Items[i];

                writer.Write(item.IsRequired);
                writer.Fill(1);
                writer.Write(item.ID);
                writer.Write(item.Lot);
            }

            writer.Write(quest.EndCondition.RequiresLocation);
            writer.Fill(1);
            writer.Write(quest.EndCondition.LocationMapID);
            writer.Fill(2);
            writer.Write(quest.EndCondition.LocationX);
            writer.Write(quest.EndCondition.LocationY);
            writer.Write(quest.EndCondition.LocationRange);
            writer.Write(quest.EndCondition.IsScenario);
            writer.Fill(1);
            writer.Write(quest.EndCondition.ScenarioID);
            writer.Write(quest.EndCondition.RequiresRace);
            writer.Write(quest.EndCondition.Race);
            writer.Write(quest.EndCondition.RequiresClass);
            writer.Write((byte) quest.EndCondition.Class);
            writer.Write(quest.EndCondition.IsTimeLimit);
            writer.Fill(1);
            writer.Write(quest.EndCondition.TimeLimit);

            writer.Write(quest.ActionCount);
            writer.Fill(3);

            for (var i = 0; i < 10; i++)
            {
                var action = quest.Actions[i];

                writer.Write((byte) action.IfType);
                writer.Fill(3);
                writer.Write(action.IfTarget);
                writer.Write((byte) action.ThenType);
                writer.Fill(3);
                writer.Write(action.ThenTarget);
                writer.Write(action.ThenPercent);
                writer.Write(action.ThenMinCount);
                writer.Write(action.ThenMaxCount);
                writer.Write((byte) action.TargetGroup);
                writer.Fill(3);
            }

            for (var i = 0; i < 12; i++)
            {
                var reward = quest.Rewards[i];

                writer.Write((byte) reward.Use);
                writer.Write((byte) reward.Type);
                writer.Fill(2);

                switch (reward.Type)
                {
                    case QuestRewardType.QRT_EXPERIENCE:
                        writer.Write(reward.Value.Experience);
                        break;
                    case QuestRewardType.QRT_MONEY:
                        writer.Write(reward.Value.Money);
                        break;
                    case QuestRewardType.QRT_ITEM:
                        writer.Write(reward.Value.ItemId);
                        writer.Write(reward.Value.ItemLot);
                        writer.Fill(4);
                        break;
                    case QuestRewardType.QRT_ABSTATE:
                        writer.Write(reward.Value.AbStateKeepTime);
                        writer.Write(reward.Value.AbstateId);
                        writer.Write(reward.Value.AbStateStrength);
                        writer.Fill(1);
                        break;
                    case QuestRewardType.QRT_FAME:
                        writer.Write(reward.Value.Fame);
                        writer.Fill(4);
                        break;
                    case QuestRewardType.QRT_PET:
                        writer.Write(reward.Value.PetId);
                        writer.Fill(4);
                        break;
                    case QuestRewardType.QRT_MINIHOUSE:
                        writer.Write(reward.Value.MiniHouseId);
                        writer.Fill(7);
                        break;
                    case QuestRewardType.QRT_TITLE:
                        writer.Write(reward.Value.TitleType);
                        writer.Write(reward.Value.TitleElementNo);
                        writer.Fill(6);
                        break;
                    case QuestRewardType.QRT_KILLPOINT:
                        writer.Write(reward.Value.KillPoints);
                        writer.Fill(4);
                        break;
                }
            }

            writer.Write((ushort) (quest.StartScript.Length + 1));
            writer.Write((ushort) (quest.EndScript.Length + 1));
            writer.Write((ushort) (quest.DoingScript.Length + 1));
            writer.Write((ushort) 0);
            writer.Write(quest.StartScriptId);
            writer.Write(quest.DoingScriptId);
            writer.Write(quest.EndScriptId);
            writer.Write(Encoding.ASCII.GetBytes(quest.StartScript + char.MinValue));
            writer.Write(Encoding.ASCII.GetBytes(quest.DoingScript + char.MinValue));
            writer.Write(Encoding.ASCII.GetBytes(quest.EndScript + char.MinValue));

            var endLength = stream.Length;

            writer.Seek((int) lengthPosition, SeekOrigin.Begin);
            writer.Write((int) (endLength - startLength));
            stream.Position = endLength;
        }

        File.WriteAllBytes(@"C:\Veritas\9Data\Shine\QuestData.shn", stream.ToArray());
        InformationText = "Quest data saved successfully.";
        
        return Task.CompletedTask;
    }
}