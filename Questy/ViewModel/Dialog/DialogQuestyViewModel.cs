using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Cogs.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Questy.Service;
using ShineData.Shine;
using ShineData.Shine.Structure.Dialog;

namespace Questy.ViewModel.Dialog;

public partial class DialogQuestyViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableSortedDictionary<uint, QuestDialog> _dialogs = QuestDialogService.Instance.QuestDialogList;
    [ObservableProperty] private string _informationText = "Dialog data has been parsed successfully!";
    
    private readonly ShineFile _file;
    private ObservableSortedDictionary<uint, QuestDialog> _originalDialogs = new();
    
    public DialogQuestyViewModel()
    {
        const string questDialog = @"C:\Veritas\9Data\Shine\View\QuestDialog.shn";

        _dialogs.Clear();
        using var file = new ShineFile(questDialog);
        _file = file;
        using var qReader = new DataTableReader(file.Table);
        
        if (!qReader.HasRows) return;
        
        while (qReader.Read())
        {
            var id = Convert.ToUInt32(qReader.GetValue(0));
            var dialog = qReader.GetString(1);
            var type = (QuestDialogType) qReader.GetByte(2);
            
            _dialogs.Add(id, new QuestDialog(id, dialog, type));
        }
        
        _originalDialogs = _dialogs;
    }

    [RelayCommand]
    private Task NewDialog()
    {
        if (QuestDialogService.Instance.QuestDialogList.Count == 0)
        {
            MessageBox.Show("Please open the quest dialog file first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return Task.CompletedTask;
        }

        var newId = QuestDialogService.Instance.QuestDialogList.LastOrDefault().Value.Id + 1;
        var questDialog = new QuestDialog(newId, "A new Dialog!", QuestDialogType.QDT_NONE);

        QuestDialogService.Instance.QuestDialogList.Add(newId, questDialog);
        InformationText = $"New dialog with ID {newId} has been created";
        
        return Task.CompletedTask;
    }

    [RelayCommand]
    private Task SaveDialogs()
    {
        _file.Table.Rows.Clear();

        foreach (var dialog in QuestDialogService.Instance.QuestDialogList)
        {
            var row = _file.Table.NewRow();
            row["ID"] = dialog.Key;
            row["Dialog"] = dialog.Value.Dialog;
            row["Type"] = (byte) dialog.Value.Type;
            _file.Table.Rows.Add(row);
        }
        
        _file.SaveFile();
        InformationText = "Dialog data has been saved successfully!";
        
        return Task.CompletedTask;
    }
}