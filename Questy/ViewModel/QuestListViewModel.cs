using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Questy.Message;
using Questy.Service;
using ShineData.Shine;
using ShineData.Shine.Structure.Dialog;
using ShineData.Shine.Structure.Quest;

namespace Questy.ViewModel;

public partial class QuestListViewModel : ObservableObject
{
    public ObservableCollection<Quest> QuestList => QuestService.Instance.QuestList;
    
    [ObservableProperty] private Quest? _selectedQuest;
    [ObservableProperty] private string? _searchTerm;
    
    private ObservableCollection<Quest> _originalQuestList = new();
    private Dictionary<uint, QuestDialog> _questNames = new();

    public QuestListViewModel()
    {
        var questData = @"C:\Veritas\9Data\Shine\QuestData.shn";
        var questDialog = @"C:\Veritas\9Data\Shine\View\QuestDialog.shn";

        using var file = new ShineFile(questDialog);
        using (var qReader = new DataTableReader(file.Table))
        {
            if (qReader.HasRows)
            {
                while (qReader.Read())
                {
                    var id = Convert.ToUInt32(qReader.GetValue(0));
                    var dialog = qReader.GetString(1);
                    var type = (QuestDialogType) qReader.GetByte(2);
                    
                    _questNames.Remove(id);
                    _questNames.Add(id, new QuestDialog(id, dialog, type));
                }
            }
        }

        using var stream = new MemoryStream(File.ReadAllBytes(questData));
        using var reader = new BinaryReader(stream);
        
        var header = reader.ReadUInt16();
        var count = reader.ReadInt16();
        
        QuestService.Instance.QuestDataHeader = header;

        for (var i = 0; i < count; i++)
        {
            var size = reader.ReadInt32();
            var data = reader.ReadBytes(size - 4);

            var parsed = Quest.Parse(data);
            parsed.Name = _questNames.FirstOrDefault(x => x.Key == parsed.NameId).Value.Dialog;

            QuestService.Instance.QuestList.Add(parsed);
            _originalQuestList.Add(parsed);
        }
    }

    partial void OnSelectedQuestChanged(Quest? value)
    {
        if (value == null)
        {
            return;
        }
        
        WeakReferenceMessenger.Default.Send(new QuestSelectionChangedMessage(value));
    }

    partial void OnSearchTermChanging(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            QuestService.Instance.QuestList = _originalQuestList;
            return;
        }

        var filtered = new ObservableCollection<Quest>(QuestService.Instance.QuestList.Where(x => x.Name.Contains(value, StringComparison.OrdinalIgnoreCase)).ToList());
        QuestService.Instance.QuestList = filtered;
    }

    partial void OnSelectedQuestChanged(Quest? oldValue, Quest? newValue)
    {
        if (oldValue == null)
        {
            return;
        }
        
        oldValue.Name = _questNames.FirstOrDefault(x => x.Key == oldValue.NameId).Value.Dialog;
    }
}