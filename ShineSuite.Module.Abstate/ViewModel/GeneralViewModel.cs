using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShineData.Shine.Files;
using ShineSuite.Module.Abstate.Manager;
using ShineSuite.Module.Abstate.Message;

namespace ShineSuite.Module.Abstate.ViewModel;

public partial class GeneralViewModel : ObservableObject, IRecipient<SelectedAbstateChangedMessage>
{
    public ObservableCollection<AbState> AbStates => ShineFileManager.Instance.AbStates;
    public ObservableCollection<AbstateMemory> AbstateMemories => ShineFileManager.Instance.AbstateMemories;
    public ObservableCollection<SubAbState> SubAbStates => ShineFileManager.Instance.SubAbStates;
    
    [ObservableProperty] private AbState? _selectedAbState;
    [ObservableProperty] private AbstateMemory? _selectedAbstateMemory;
    [ObservableProperty] private ObservableCollection<SubAbState>? _selectedSubAbState;
    [ObservableProperty] private SubAbState? _selectedStrength;

    [ObservableProperty] private bool _isAbstateMemoryVisible = false;
    [ObservableProperty] private bool _isSubAbStateVisible = false;

    public GeneralViewModel()
    {
        WeakReferenceMessenger.Default.Register(this);
    }

    public void Receive(SelectedAbstateChangedMessage message)
    {
        SelectedAbState = message.Value;

        var abstateMemory = AbstateMemories.FirstOrDefault(x => x.AbstateIndex == (uint) message.Value.AbstateIndex);
        
        if (abstateMemory != null)
        {
            SelectedAbstateMemory = abstateMemory;
            IsAbstateMemoryVisible = true;
        }
        
        var subAbState = new ObservableCollection<SubAbState>(SubAbStates.Where(x => x.InxName == message.Value.SubAbstate).ToList());
        
        if (subAbState.Count > 0)
        {
            SelectedSubAbState = subAbState;
            IsSubAbStateVisible = true;
        }
    }

    [RelayCommand]
    private void AddNewSubAbstate()
    {
        if (SelectedSubAbState == null)
        {
            return;
        }

        var lastItem = SelectedSubAbState.Last();
        var newItem = new SubAbState
        {
            Id = (ushort) (SubAbStates.OrderBy(x => x.Id).LastOrDefault()?.Id + 1 ?? 1),
            InxName = lastItem.InxName,
            Strength = lastItem.Strength + 1,
            Type = lastItem.Type,
            SubType = lastItem.SubType,
            KeepTime = lastItem.KeepTime,
            ActionIndex01 = lastItem.ActionIndex01,
            ActionArg01 = lastItem.ActionArg01,
            ActionIndex02 = lastItem.ActionIndex02,
            ActionArg02 = lastItem.ActionArg02,
            ActionIndex03 = lastItem.ActionIndex03,
            ActionArg03 = lastItem.ActionArg03,
            ActionIndex04 = lastItem.ActionIndex04,
            ActionArg04 = lastItem.ActionArg04
        };
        
        SelectedSubAbState.Add(newItem);
    }
}