using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShineData.Shine;
using ShineData.Shine.Files;
using ShineData.Shine.Structure.Enum;
using ShineSuite.Common.Manager;
using ShineSuite.Module.Abstate.Message;
using ShineSuite.Module.Abstate.Window;

namespace ShineSuite.Module.Abstate.ViewModel;

public partial class AbstateListModel : ObservableObject
{
    public BaseShineFile<AbStateEntry> AbnormalState => ShineFileManager.Instance.AbState;
    
    [ObservableProperty] private AbStateEntry? _selectedAbState;
    
    public AbstateListModel()
    {
        
    }

    partial void OnSelectedAbStateChanged(AbStateEntry? value)
    {
        if (value == null) return;

        WeakReferenceMessenger.Default.Send(new SelectedAbstateChangedMessage(value));
    }

    [RelayCommand]
    private void CreateAbstate()
    {
        var createWindow = new NewAbstateWindow();
        if (createWindow.ShowDialog() == true)
        {
            var newAbstateIndex = AbnormalState.Records.OrderBy(x => (uint) x.AbstateIndex).Last().AbstateIndex + 1;
        
            var newAbstate = new AbStateEntry
            {
                Id = (ushort)(AbnormalState.Records.LastOrDefault()!.Id + 1),
                InxName = createWindow.AbstateName,
                AbstateIndex = newAbstateIndex,
                KeepTimeRatio = 1000,
                KeepTimePower = 1,
                AbstateSaveType = AbstateSaveType.AST_NONE,
                DispelAttribute = DispelAttribute.DA_NONE,
                Duplicate = 0,
                MainStateInx = "-",
                SubAbstate = $"Sub{createWindow.AbstateName}",
            };
        
            ShineFileManager.Instance.AbState.Records.Add(newAbstate);

            var newMemory = new AbstateMemoryEntry
            {
                AbstateIndex = (uint) newAbstateIndex,
                AbstateMemoryStruct = AbstateMemoryStruct.AMS_ELEMENT_NORMAL,
                SubAbstateAction = 0
            };
        
            ShineFileManager.Instance.AbstateMemory.Records.Add(newMemory);

            var newSubAbstate = new SubAbStateEntry
            {
                Id = (ushort)(ShineFileManager.Instance.SubAbState.Records.LastOrDefault()!.Id + 1),
                InxName = $"Sub{createWindow.AbstateName}",
                Strength = 1,
                Type = SubState.SUBAB_DEFAULT,
                SubType = 1,
                KeepTime = 1000,
                ActionIndex01 = SubAbstateAction.SAA_NONE,
                ActionArg01 = 0,
                ActionIndex02 = SubAbstateAction.SAA_NONE,
                ActionArg02 = 0,
                ActionIndex03 = SubAbstateAction.SAA_NONE,
                ActionArg03 = 0,
                ActionIndex04 = SubAbstateAction.SAA_NONE,
                ActionArg04 = 0,
            };
        
            ShineFileManager.Instance.SubAbState.Records.Add(newSubAbstate);

            var newAbstateView = new AbStateViewEntry
            {
                Id = (ushort) (ShineFileManager.Instance.AbStateView.Records.LastOrDefault().Id + 1),
                InxName = createWindow.AbstateName,
                Icon = 0,
                IconFile = "AbState00",
                Description = "A magical effect!",
                Red = 0,
                Green = 0,
                Blue = 0,
                AnimationIndex = "-",
                EffectName = "-",
                EffectNamePosition = EffectPosition.EP_NONE,
                EffectRefresh = 0,
                LoopEffect = "-",
                LoopEffectPosition = EffectPosition.EP_NONE,
                LastEffect = "-",
                LastEffectPosition = EffectPosition.EP_NONE,
                DamageOverTimeEffect = "-",
                DamageOverTimeEffectPosition = EffectPosition.EP_NONE,
                IconSort = "DEBUFF",
                TypeSort = StateType.ST_NORMAL,
                View = 1
            };
            
            ShineFileManager.Instance.AbStateView.Records.Add(newAbstateView);
        }
    }
}