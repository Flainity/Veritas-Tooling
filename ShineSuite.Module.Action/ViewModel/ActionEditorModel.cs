using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShineData.Shine.Files;
using ShineData.Shine.Structure.Enum;
using ShineData.Shine.Structure.Enum.Action;
using ShineData.Shine.Structure.Enum.Action.Activity;
using ShineData.Shine.Wrapper;
using ShineSuite.Common.Manager;
using ShineSuite.Module.Action.Message;

namespace ShineSuite.Module.Action.ViewModel;

public partial class ActionEditorModel : ObservableObject, IRecipient<SelectedItemActionChanged>
{
    public BaseShineFile<ItemActionEntry> ItemAction => ShineFileManager.Instance.ItemAction;
    public BaseShineFile<ItemActionEffectDescEntry> ItemActionCoolTime => ShineFileManager.Instance.ItemActionEffectDesc;
    
    [ObservableProperty] private ItemActionEffectDescEntry _selectedItemActionEffectDesc;
    [ObservableProperty] private ObservableCollection<ItemActionEntry> _itemActions = new();
    [ObservableProperty] private ObservableCollection<ItemActionEffectEntry> _itemActionEffects = new();
    [ObservableProperty] private ObservableCollection<ItemActionConditionEntry> _itemActionConditions = new();
    [ObservableProperty] private ObservableCollection<ActionPairModel> _actionPairs = new();
    [ObservableProperty] private ActionPairModel _selectedActionPair;

    public ActionEditorModel()
    {
        WeakReferenceMessenger.Default.Register(this);
    }
    
    public void Receive(SelectedItemActionChanged message)
    {
        SelectedItemActionEffectDesc = message.Value;
        
        ActionPairs.Clear();
        ItemActions.Clear();
        ItemActionEffects.Clear();
        ItemActionConditions.Clear();
        
        var itemAction = ShineFileManager.Instance.ItemAction.Records
            .Where(x => x.Id == SelectedItemActionEffectDesc.Id)
            .ToList();
        
        if (itemAction.Count == 0)
        {
            return;
        }
        
        foreach (var action in itemAction)
        {
            ItemActions.Add(action);
            ActionPairs.Add(new ActionPairModel(action));
        }
        
        foreach (var effect in itemAction.Select(action => ShineFileManager.Instance.ItemActionEffect.Records.FirstOrDefault(x => x.Id == action.EffectId)).OfType<ItemActionEffectEntry>())
        {
            ItemActionEffects.Add(effect);
        }
        
        foreach (var condition in itemAction.Select(action => ShineFileManager.Instance.ItemActionCondition.Records.FirstOrDefault(x => x.Id == action.ConditionId)).OfType<ItemActionConditionEntry>())
        {
            ItemActionConditions.Add(condition);
        }
        
        SelectedActionPair = ActionPairs.FirstOrDefault();
    }

    [RelayCommand]
    private void CreateNewPair()
    {
        var newActionEffect = new ItemActionEffectEntry
        {
            Id = (ushort)(ShineFileManager.Instance.ItemActionEffect.Records.Max(x => x.Id) + 1),
            EffectTarget = new ActionTargetWrapper
            {
                TargetItem01 = ActionTargetType.ATT_TARGET_TYPE,
                TargetItem02 = new TargetTypeEnum(TargetType.TARGET_ENEMY)
            },
            EffectActivity = new ActionActivityWrapper
            {
                TargetItem01 = ActionActivityType.AAT_ATTACK_TYPE,
                TargetItem02 = new AttackTypeEnum(AttackType.AT_NORMAL)
            },
            Value = 0,
            Area = 0,
            Explanation = "-"
        };
        
        ShineFileManager.Instance.ItemActionEffect.Records.Add(newActionEffect);
        
        var newActionCondition = new ItemActionConditionEntry
        {
            Id = (ushort)(ShineFileManager.Instance.ItemActionCondition.Records.Max(x => x.Id) + 1),
            SubjectTarget = new ActionTargetWrapper
            {
                TargetItem01 = ActionTargetType.ATT_TARGET_TYPE,
                TargetItem02 = new TargetTypeEnum(TargetType.TARGET_ENEMY)
            },
            ObjectTarget = new ActionTargetWrapper
            {
                TargetItem01 = ActionTargetType.ATT_TARGET_TYPE,
                TargetItem02 = new TargetTypeEnum(TargetType.TARGET_ENEMY)
            },
            ConditionActivity = new ActionActivityWrapper
            {
                TargetItem01 = ActionActivityType.AAT_ATTACK_TYPE,
                TargetItem02 = new AttackTypeEnum(AttackType.AT_NORMAL)
            },
            ActivityRate = 1000,
            Range = 2400
        };
        
        ShineFileManager.Instance.ItemActionCondition.Records.Add(newActionCondition);
        
        var newAction = new ItemActionEntry
        {
            Id = SelectedItemActionEffectDesc.Id,
            EffectId = newActionEffect.Id,
            ConditionId = newActionCondition.Id,
            CoolTime = 0,
            CoolGroupActionId = 0,
            Description = "None",
            PairNumber = (ushort)(ShineFileManager.Instance.ItemAction.Records.Where(x => x.Id == SelectedItemActionEffectDesc.Id).Max(x => x.PairNumber) + 1)
        };
        
        ShineFileManager.Instance.ItemAction.Records.Add(newAction);
        
        ItemActions.Add(newAction);
        ActionPairs.Add(new ActionPairModel(newAction));
        SelectedActionPair = ActionPairs.Last();
    }

    [RelayCommand]
    private void SaveActions()
    {
        ShineFileManager.Instance.ItemActionCondition.Save();
        ShineFileManager.Instance.ItemActionEffect.Save();
        ShineFileManager.Instance.ItemAction.Save();
        ShineFileManager.Instance.ItemActionEffectDesc.Save();

        WeakReferenceMessenger.Default.Send(new ActionsSavedMessage(true));
    }
}