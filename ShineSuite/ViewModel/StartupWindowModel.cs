using System;
using CommunityToolkit.Mvvm.ComponentModel;
using ShineData.Shine;
using ShineData.Shine.Files;
using ShineSuite.Common.Manager;

namespace ShineSuite.ViewModel;

public partial class StartupWindowModel : ObservableObject
{
    public event EventHandler? ShineFilesLoaded;
    
    public StartupWindowModel()
    {
        InstantiateShineFiles();
    }

    private async void InstantiateShineFiles()
    {
        ShineFileManager.Instance.AbState = await ShineClass.LoadAsync<AbState, AbStateEntry>("AbState.shn");
        ShineFileManager.Instance.AbstateMemory = await ShineClass.LoadAsync<AbstateMemory, AbstateMemoryEntry>("AbstateMemory.shn");
        ShineFileManager.Instance.SubAbState = await ShineClass.LoadAsync<SubAbState, SubAbStateEntry>("SubAbState.shn");
        ShineFileManager.Instance.AbStateView = await ShineClass.LoadAsync<AbStateView, AbStateViewEntry>(@"View\AbStateView.shn");
        
        ShineFileManager.Instance.ItemAction = await ShineClass.LoadAsync<ItemAction, ItemActionEntry>("ItemAction.shn");
        ShineFileManager.Instance.ItemActionCondition = await ShineClass.LoadAsync<ItemActionCondition, ItemActionConditionEntry>("ItemActionCondition.shn");
        ShineFileManager.Instance.ItemActionEffect = await ShineClass.LoadAsync<ItemActionEffect, ItemActionEffectEntry>("ItemActionEffect.shn");
        ShineFileManager.Instance.ItemActionEffectDesc = await ShineClass.LoadAsync<ItemActionEffectDesc, ItemActionEffectDescEntry>(@"View\ItemActionEffectDesc.shn");
        
        ShineFileManager.Instance.ActiveSkill = await ShineClass.LoadAsync<ActiveSkill, ActiveSkillEntry>("ActiveSkill.shn");
        ShineFileManager.Instance.ActiveSkillInfoServer = await ShineClass.LoadAsync<ActiveSkillInfoServer, ActiveSkillInfoServerEntry>("ActiveSkillInfoServer.shn");
        ShineFileManager.Instance.ActiveSkillView = await ShineClass.LoadAsync<ActiveSkillView, ActiveSkillViewEntry>(@"View\ActiveSkillView.shn");
        
        ShineFilesLoaded?.Invoke(this, EventArgs.Empty);
    }
}