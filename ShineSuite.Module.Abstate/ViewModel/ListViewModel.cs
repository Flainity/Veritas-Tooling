using System.Collections.ObjectModel;
using Cogs.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using ShineData.Shine;
using ShineData.Shine.Files;
using ShineSuite.Module.Abstate.Manager;
using ShineSuite.Module.Abstate.Message;

namespace ShineSuite.Module.Abstate.ViewModel;

public partial class ListViewModel : ObservableObject
{
    public ObservableCollection<AbState> AbStates => ShineFileManager.Instance.AbStates;
    public ObservableCollection<AbstateMemory> AbstateMemories => ShineFileManager.Instance.AbstateMemories;
    public ObservableCollection<SubAbState> SubAbStates => ShineFileManager.Instance.SubAbStates;
    
    [ObservableProperty] private AbState? _selectedAbState;
    
    public ListViewModel()
    {
        ShineFileManager.Instance.AbStates = new ObservableCollection<AbState>(ShineClass.Load<AbState>("AbState.shn"));
        ShineFileManager.Instance.AbstateMemories = new ObservableCollection<AbstateMemory>(ShineClass.Load<AbstateMemory>("AbstateMemory.shn"));
        ShineFileManager.Instance.SubAbStates = new ObservableCollection<SubAbState>(ShineClass.Load<SubAbState>("SubAbState.shn"));
    }

    partial void OnSelectedAbStateChanged(AbState? value)
    {
        if (value == null) return;

        WeakReferenceMessenger.Default.Send(new SelectedAbstateChangedMessage(value));
    }
}