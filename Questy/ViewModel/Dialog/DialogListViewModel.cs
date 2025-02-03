using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Cogs.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Questy.Helper;
using Questy.Message;
using Questy.Service;
using ShineData.Shine;
using ShineData.Shine.Structure.Dialog;
using ShineData.Shine.Structure.Quest;

namespace Questy.ViewModel.Dialog;

public partial class DialogListViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Quest> _questList = QuestService.Instance.QuestList;

    [ObservableProperty]
    private ObservableSortedDictionary<uint, QuestDialog> _dialogs = QuestDialogService.Instance.QuestDialogList;
    
    [ObservableProperty] private QuestDialog? _selectedDialog;
    [ObservableProperty] private QuestDialogType? _dialogTypeFilter;
    [ObservableProperty] private Quest? _selectedQuestFilter;
    
    private ObservableSortedDictionary<uint, QuestDialog> _originalDialogs = new();

    partial void OnSelectedDialogChanged(QuestDialog? value)
    {
        if (value == null) return;
        
        WeakReferenceMessenger.Default.Send(new DialogSelectionChangedMessage(value));
    }

    partial void OnDialogTypeFilterChanged(QuestDialogType? value)
    {
        var dialogsToFilter = _originalDialogs;

        if (SelectedQuestFilter != null)
        {
            dialogsToFilter = Dialogs;
        }

        var filtered = dialogsToFilter.Where(x => x.Value.Type == value).ToDictionary(x => x.Key, x => x.Value);
        Dialogs = new ObservableSortedDictionary<uint, QuestDialog>(filtered);
    }

    partial void OnSelectedQuestFilterChanged(Quest? value)
    {
        if (value == null)
        {
            return;
        }

        List<int> dialogIds = new();
        dialogIds.Add(value.NameId);
        dialogIds.Add(value.BriefId);

        var startScriptNumbers = ScriptParser.ExtractSayNumbers(value.StartScript);
        var doingScriptNumbers = ScriptParser.ExtractSayNumbers(value.DoingScript);
        var endScriptNumbers = ScriptParser.ExtractSayNumbers(value.EndScript);

        dialogIds.AddRange(startScriptNumbers);
        dialogIds.AddRange(doingScriptNumbers);
        dialogIds.AddRange(endScriptNumbers);

        dialogIds = dialogIds.Distinct().ToList();
        
        var filtered = _originalDialogs.Where(x => dialogIds.Contains((int)x.Key)).ToDictionary(x => x.Key, x => x.Value);
        Dialogs = new ObservableSortedDictionary<uint, QuestDialog>(filtered);
    }

    [RelayCommand]
    private Task ResetFilter()
    {
        SelectedQuestFilter = null;
        DialogTypeFilter = null;
        Dialogs = _originalDialogs;
        
        return Task.CompletedTask;
    }
}